using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AstralNovastrom.src.Models;
using System.Collections.ObjectModel;

namespace AstralNovastrom.src.ViewModels
{
    public partial class LogViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _logFilter = "全部";

        [ObservableProperty]
        private int _totalLogs = 0;

        [ObservableProperty]
        private int _criticalLogs = 0;

        [ObservableProperty]
        private int _warningLogs = 0;

        public ObservableCollection<LogEntry> Logs { get; set; }

        public LogViewModel()
        {
            Logs = new ObservableCollection<LogEntry>();
            InitializeSampleData();
            UpdateLogCounts();
        }

        private void InitializeSampleData()
        {
            // 添加示例日志
            Logs.Add(new LogEntry
            {
                Message = "系统启动完成",
                Type = LogType.Info,
                Timestamp = DateTime.Now
            });

            Logs.Add(new LogEntry
            {
                Message = "反应堆初始化成功",
                Type = LogType.Info,
                Timestamp = DateTime.Now.AddSeconds(-10)
            });

            Logs.Add(new LogEntry
            {
                Message = "处理器温度接近阈值",
                Type = LogType.Warning,
                Timestamp = DateTime.Now.AddMinutes(-5)
            });

            Logs.Add(new LogEntry
            {
                Message = "检测到异常网络活动",
                Type = LogType.Critical,
                Timestamp = DateTime.Now.AddMinutes(-10)
            });

            Logs.Add(new LogEntry
            {
                Message = "能量提取效率达到95%",
                Type = LogType.Info,
                Timestamp = DateTime.Now.AddMinutes(-15)
            });
        }

        [RelayCommand]
        private void ClearLogs()
        {
            Logs.Clear();
            UpdateLogCounts();
        }

        [RelayCommand]
        private void FilterLogs(string filter)
        {
            LogFilter = filter;
            // 实现日志过滤逻辑
        }

        [RelayCommand]
        private void ExportLogs()
        {
            // 实现日志导出逻辑
        }

        public void AddLog(LogEntry log)
        {
            Logs.Insert(0, log);
            UpdateLogCounts();
        }

        private void UpdateLogCounts()
        {
            TotalLogs = Logs.Count;
            CriticalLogs = Logs.Count(l => l.Type == LogType.Critical);
            WarningLogs = Logs.Count(l => l.Type == LogType.Warning);
        }
    }
}
