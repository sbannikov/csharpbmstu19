using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace MyService
{
    partial class UsefulService : ServiceBase
    {
        /// <summary>
        /// Наблюдатель файловой системы
        /// </summary>
        System.IO.FileSystemWatcher watcher;

        /// <summary>
        /// Таймер
        /// </summary>
        System.Timers.Timer timer;

        public UsefulService()
        {
            InitializeComponent();

            // Наблюдатель файловой системы
            watcher = new System.IO.FileSystemWatcher();
            watcher.Path = @"C:\TEST";
            watcher.IncludeSubdirectories = true;
            watcher.Created += Watcher_Event;
            watcher.Changed += Watcher_Event;
            watcher.Deleted += Watcher_Event;
            watcher.Renamed += Watcher_Event;

            // Таймер
            timer = new System.Timers.Timer();
            timer.Interval = Properties.Settings.Default.Interval;
            timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
#if DEBUG
                timer.Enabled = false;
#endif
                EventLog.WriteEntry($"Московское время {DateTime.Now}", EventLogEntryType.Information);
            }
            catch (Exception ex)
            {
                WriteException(ex);
            }
            finally
            {
#if DEBUG
                timer.Enabled = true;
#endif
            }
        }

        private void Watcher_Event(object sender, System.IO.FileSystemEventArgs e)
        {
            try
            {
                EventLog.WriteEntry($"{e.FullPath} {e.ChangeType}", EventLogEntryType.Information);
            }
            catch (Exception ex)
            {
                WriteException(ex);
            }
        }

        /// <summary>
        /// Протоколирование исключения
        /// /// </summary>
        /// <param name="ex">Исключение</param>
        private void WriteException(Exception ex)
        {
            string message;
            message = string.Format("{0}: {1}", ex.GetType().FullName, ex.Message);
            EventLog.WriteEntry(message, EventLogEntryType.Error, (int)EventID.Exception);
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                base.OnStart(args);
                watcher.EnableRaisingEvents = true;
                timer.Enabled = true;
                EventLog.WriteEntry("Сервис запущен",
                    EventLogEntryType.Information,
                    (int)EventID.Start);
            }
            catch (Exception ex)
            {
                WriteException(ex);
            }
        }

        /// <summary>
        /// Запуск сервиса вручную для консольного режима
        /// </summary>
        public void StartService()
        {
            OnStart(null);
        }

        protected override void OnStop()
        {
            try
            {
                base.OnStop();
                watcher.EnableRaisingEvents = false;
                timer.Enabled = false;
                EventLog.WriteEntry("Сервис остановлен",
                    EventLogEntryType.Information,
                    (int)EventID.Stop);
            }
            catch (Exception ex)
            {
                WriteException(ex);
            }
        }

        protected override void OnPause()
        {
            try
            {
                base.OnPause();
                watcher.EnableRaisingEvents = false;
                timer.Enabled = false;
                EventLog.WriteEntry("Сервис приостановлен",
                    EventLogEntryType.Information,
                    (int)EventID.Pause);
            }
            catch (Exception ex)
            {
                WriteException(ex);
            }
        }

        protected override void OnContinue()
        {
            try
            {
                base.OnContinue();
                watcher.EnableRaisingEvents = true;
                timer.Enabled = true;
                EventLog.WriteEntry("Сервис возобнолен",
                    EventLogEntryType.Information,
                    (int)EventID.Continue);
            }
            catch (Exception ex)
            {
                WriteException(ex);
            }
        }
    }
}
