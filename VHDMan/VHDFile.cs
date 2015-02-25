using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VHDMan
{
    /// <summary>
    /// VHDFile represent a VHD file on the hard disk.
    /// You can mount, unmount or delete the vhd file by
    /// its corresponding object.
    /// </summary>
    public class VHDFile
    {
        /// <summary>
        /// Path of the VHD file.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Mount the VHD file as read only?
        /// </summary>
        public bool ReadOnly { get; set; }

        /// <summary>
        /// ctor.
        /// </summary>
        /// <param name="path">path of the VHD file</param>
        /// <param name="readOnly">mount the VHD file as read only?</param>
        public VHDFile(string path, bool readOnly)
        {
            Path = path;
            ReadOnly = readOnly;
        }

        /// <summary>
        /// Call system utility 'disk-part' and load the specified script file.
        /// </summary>
        /// <param name="scriptText">actions to be taken in the disk-part</param>
        /// <returns>if diskpart succeeds</returns>
        private bool CallDiskpart(string scriptText)
        {
            if (scriptText == null) return false;

            // Create a diskpart-script file.
            StreamWriter strmWriter = new StreamWriter("~tmp.txt");
            strmWriter.Write(scriptText);
            strmWriter.Close();

            // Execute disk-part and load script file.
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = "diskpart";
            psi.Arguments = "-s " + Application.StartupPath + @"\~tmp.txt";
            psi.WindowStyle = ProcessWindowStyle.Hidden;
            Process proc = Process.Start(psi);
            proc.WaitForExit();

            // Remove temp file.
            FileInfo fi = new FileInfo("~tmp.txt");
            fi.Delete();

            return proc.ExitCode == 0;
        }

        /// <summary>
        /// Create a vhd file.
        /// </summary>
        /// <param name="sizeInMegabytes">vhd size in MB</param>
        /// <param name="prealloc">preallocate space for vhd size or not</param>
        /// <param name="fastpart">fast partition the vhd</param>
        /// <returns>if creation succeeds</returns>
        public bool Create(int sizeInMegabytes, bool prealloc, bool fastpart)
        {
            // Script text.
            string text = "create vdisk file=\"" + Path + "\" maximum=" + sizeInMegabytes + " type=";
            if (prealloc)
                text += "fixed";
            else
                text += "expandable";

            if (fastpart)
            {
                text += Environment.NewLine + "select vdisk file=\"" + Path + "\"";
                text += Environment.NewLine + "attach vdisk";
                text += Environment.NewLine + "convert mbr";
                text += Environment.NewLine + "create partition primary";
                text += Environment.NewLine + "format";
                text += Environment.NewLine + "assign";
            }
            text += Environment.NewLine + "exit";
            
            // Call Diskpart.
            return CallDiskpart(text);
        }

        /// <summary>
        /// Mount the vhd file.
        /// </summary>
        /// <returns>if mount succeeds</returns>
        public bool Mount()
        {
            // Script text.
            string text = "select vdisk file=" + Path + Environment.NewLine;
            if (ReadOnly)
                text += "attach vdisk readonly";
            else
                text += "attach vdisk";
            text += Environment.NewLine + "exit";

            // Call Diskpart.
            return CallDiskpart(text);
        }

        /// <summary>
        /// Unmount the vhd file.
        /// </summary>
        /// <returns>if unmount succeeds</returns>
        public bool Unmount()
        {
            // Script text.
            string text = "select vdisk file=" + Path + Environment.NewLine +
                          "detach vdisk" + Environment.NewLine +
                          "exit";
 
            // Call Diskpart.
            return CallDiskpart(text);
        }

        /// <summary>
        /// Delete the vhd file from disk.
        /// </summary>
        /// <returns>if deletion succeeds</returns>
        public bool DeleteFromDisk()
        {
            // First try to unmount it anyway.
            if (!Unmount()) return false;

            // Delete it from disk.
            FileInfo fi = new FileInfo(Path);
            if (fi.Exists)
                fi.Delete();

            // Confirm deletion.
            fi.Refresh();
            return !fi.Exists;
        }

        /// <summary>
        /// Get hash code of the object.
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Equals only when the property 'Path' of the two VHDFile objects equal.
        /// </summary>
        /// <param name="obj">another object</param>
        /// <returns>equals or not</returns>
        public override bool Equals(object obj)
        {
            VHDFile vhdFile = obj as VHDFile;
            if (vhdFile == null)
                return false;
            return vhdFile.Path.Equals(Path);
        }

        /// <summary>
        /// String to show some info about the vhd file.
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            string result = Path;
            if (ReadOnly)
                result += "[只读模式]";
            return result;
        }
    }
}
