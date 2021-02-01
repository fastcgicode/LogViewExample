using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Windows.Controls;
using LogViewExample.Models;

namespace LogViewExample.Views
{
    /// <summary>
    /// Interaction logic for LogViewControl.xaml
    /// </summary>
    public partial class LogViewControl : UserControl
    {
        ViewModels.LogView logView;
        ObservableCollection<LogEntry> logEntries;
        Timer timer;
        public LogViewControl()
        {
            InitializeComponent();

            logView = new ViewModels.LogView();
            logEntries = logView.LogEntries;
            timer = new Timer(x => AddRandomEntry(), null, 1000, 10);

            DataContext = logEntries;
        }

        private void AddRandomEntry()
        {
            Dispatcher.BeginInvoke((Action)(() => logEntries.Add(logView.GetRandomEntry())));
        }
    }
}
