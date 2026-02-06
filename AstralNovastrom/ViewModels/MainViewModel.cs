using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AstralNovastrom.Models;
using System.Collections.ObjectModel;
using System.Windows.Threading;

namespace AstralNovastrom.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _systemStatus = "在线";

        [ObservableProperty]
        private bool _isSystemOnline = true;

        [ObservableProperty]
        private string _currentMode = "正常";

        [ObservableProperty]
        private double _systemLoad = 47.0;

        public ObservableCollection<LogEntry> RecentLogs { get; set; }
        public ObservableCollection<SecurityAlert> ActiveAlerts { get; set; }
        public ReactorStatus ReactorStatus { get; set; }
        public ProcessorMetrics ProcessorMetrics { get; set; }

        private DispatcherTimer? _updateTimer;

        public MainViewModel()
        {
            RecentLogs = new ObservableCollection<LogEntry>();
            ActiveAlerts = new ObservableCollection<SecurityAlert>();
            ReactorStatus = new ReactorStatus();
            ProcessorMetrics = new ProcessorMetrics();

            InitializeTimer();
            InitializeSampleData();
        }

        private void InitializeTimer()
        {
            _updateTimer = new DispatcherTimer();
            _updateTimer.Interval = TimeSpan.FromSeconds(1);
            _updateTimer.Tick += UpdateTimer_Tick;
            _updateTimer.Start();
        }

        private void UpdateTimer_Tick(object? sender, EventArgs e)
        {
            // 模拟数据更新
            SystemLoad = (SystemLoad + 0.1) % 100;
            ReactorStatus.PsiStability = 7.0 + Math.Sin(DateTime.Now.Ticks * 0.0001) * 0.5;
            ProcessorMetrics.LoadPercentage = (ProcessorMetrics.LoadPercentage + 0.2) % 100;
        }

        private void InitializeSampleData()
        {
            // 添加示例日志
            RecentLogs.Add(new LogEntry
            {
                Message = "系统启动完成",
                Type = LogType.Info,
                Timestamp = DateTime.Now
            });

            RecentLogs.Add(new LogEntry
            {
                Message = "反应堆初始化成功",
                Type = LogType.Info,
                Timestamp = DateTime.Now.AddSeconds(-10)
            });

            // 添加示例警报
            ActiveAlerts.Add(new SecurityAlert
            {
                Message = "检测到异常网络活动",
                ThreatLevel = ThreatLevel.Medium,
                Timestamp = DateTime.Now.AddMinutes(-5),
                Source = "防火墙"
            });
        }

        [RelayCommand]
        private void RefreshData()
        {
            // 刷新数据逻辑
            SystemStatus = "刷新中...";
            SystemStatus = "在线";
        }

        [RelayCommand]
        private void ToggleSystemMode()
        {
            CurrentMode = CurrentMode == "正常" ? "维护" : "正常";
        }
    }
}