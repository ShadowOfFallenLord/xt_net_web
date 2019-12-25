using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HW_Task_05.Common
{
    static class RecoveryMaster
    {
        public static string[] GetVersions()
        {
            string path = ValueKeeper.Root + "\\"
                + ValueKeeper.BackUpFolder;

            if (!Directory.Exists(path))
            {
                return new string[0];
            }

            return new DirectoryInfo(path).GetDirectories().Select((x) => x.Name).ToArray();
        }

        public static bool RecoverySave(string version)
        {
            string path = ValueKeeper.Root + "\\"
                + ValueKeeper.BackUpFolder + "\\"
                + version;

            if (!Directory.Exists(path)) return false;

            ClearRoot();
            CopyToRoot(path);

            return true;
        }

        private static void ClearRoot()
        {
            DirectoryInfo directory = new DirectoryInfo(ValueKeeper.Root);

            foreach(FileInfo file in directory.GetFiles())
            {
                file.Delete();
            }

            foreach(DirectoryInfo dir in directory.GetDirectories())
            {
                if (dir.FullName.Contains(ValueKeeper.BackUpFolder)) continue;

                dir.Delete(true);
            }
        }

        private static void CopyToRoot(string path, string additional = "")
        {
            DirectoryInfo directory = new DirectoryInfo(path);

            foreach (FileInfo file in directory.GetFiles())
            {
                file.CopyTo(ValueKeeper.Root + additional + "\\" + file.Name);
            }

            foreach (DirectoryInfo dir in directory.GetDirectories())
            {
                string new_path = dir.FullName;
                string new_add = additional + "\\" + dir.Name;
                CopyToRoot(new_path, new_add);
            }
        }
    }
}
