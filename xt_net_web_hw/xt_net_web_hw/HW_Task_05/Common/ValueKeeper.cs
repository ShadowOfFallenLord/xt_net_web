using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Task_05.Common
{
    static class ValueKeeper
    {
        public const string ObservedFileFormat = "*.txt";
        static public readonly string Root = Environment.CurrentDirectory + "\\files";
        public const string BackUpFolder = ".backups";
        public const string BackUpStory = ".story";
    }
}
