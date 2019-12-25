using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HW_Task_05.Common
{
    static class BackUpper
    {
        public static string ToBackUpName(this DateTime date)
        {
            return $"{date.Year:d4}_{date.Month:d2}_{date.Day:d2}_" +
                $"{date.Hour:d2}_{date.Minute:d2}_{date.Second:d2}_" +
                $"{date.Millisecond:d3}";
        }

        public static void BackUp(DateTime date)
        {
            string path = ValueKeeper.Root;
            string backup_folder = path + "\\" + ValueKeeper.BackUpFolder;

            if(!Directory.Exists(backup_folder))
            {
                Directory.CreateDirectory(backup_folder);
            }

            string back_up_name = date.ToBackUpName();

            string story_file = backup_folder + "\\" + ValueKeeper.BackUpStory;
            if(!File.Exists(story_file))
            {
                File.Create(story_file).Close();
            }

            using(StreamWriter file = new StreamWriter(story_file, true))
            {
                file.Write(back_up_name);
                file.Write("\0");
            }

            string current_back_up_folder = backup_folder + "\\" + back_up_name;
            Directory.CreateDirectory(current_back_up_folder);

            SaveDirectory(ValueKeeper.Root, current_back_up_folder);
        }

        private static void SaveDirectory(string path, string save_path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);

            if(!Directory.Exists(save_path))
            {
                Directory.CreateDirectory(save_path);
            }
            save_path += "\\";

            foreach (FileInfo file in directory.GetFiles())
            {
                File.Copy(file.FullName, save_path + file.Name);
            }

            foreach (DirectoryInfo dir in directory.GetDirectories())
            {
                if (dir.Name.Contains(".")) continue;

                SaveDirectory(dir.FullName, save_path + dir.Name);
            }
        }
    }
}
