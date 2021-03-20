using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;

namespace HW_Task_05.Common
{
    class Observer
    {
        private bool log_into_console;
        private FileSystemWatcher observer;
        public Action<DateTime> OnUpdate;

        public Observer(bool log_into_console = false)
        {
            this.log_into_console = log_into_console;
            observer = new FileSystemWatcher(ValueKeeper.Root);
            observer.NotifyFilter = NotifyFilters.LastAccess
                                    | NotifyFilters.LastWrite
                                    | NotifyFilters.FileName
                                    | NotifyFilters.DirectoryName
                                    | NotifyFilters.CreationTime;
            observer.IncludeSubdirectories = true;
            observer.Changed += Changed;
            observer.Created += Changed;
            observer.Deleted += Changed;
            observer.Renamed += Changed;
        }

        public void StartObserve()
        {
            observer.EnableRaisingEvents = true;
        }

        public void StopObserve()
        {
            observer.EnableRaisingEvents = false;
        }

        private void Changed(object sender, FileSystemEventArgs e)
        {
            observer.EnableRaisingEvents = false;
            string event_path = e.FullPath;
            if (event_path.Contains(ValueKeeper.BackUpFolder)) return;
            if (!event_path.Contains(".txt") && e.ChangeType == WatcherChangeTypes.Changed) return;
            if (event_path.Contains(".") && !event_path.Contains(".txt")) return;

            if (log_into_console)
            {
                Console.WriteLine($"{e.Name} was {e.ChangeType}");
                Console.WriteLine($"({event_path})");
            }

            OnUpdate?.Invoke(DateTime.Now);
            observer.EnableRaisingEvents = true;
        }
    }
}
