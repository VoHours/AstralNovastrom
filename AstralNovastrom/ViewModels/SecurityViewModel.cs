using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AstralNovastrom.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace AstralNovastrom.ViewModels
{
    public partial class SecurityViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _securityStatus = "正常";

        [ObservableProperty]
        private int _activeAlerts = 0;

        [ObservableProperty]
        private int _totalHacksAttempted = 5;

        [ObservableProperty]
        private int _successfulBlocks = 4;

        [ObservableProperty]
        private bool _isFirewallEnabled = true;

        [ObservableProperty]
        private bool _isHackProtectionEnabled = true;

        public ObservableCollection<SecurityAlert> Alerts { get; set; }

        public SecurityViewModel()
        {
            Alerts = new ObservableCollection<SecurityAlert>();
            InitializeSampleData();
            UpdateAlertCount();
        }

        private void InitializeSampleData()
        {
            // 添加示例警报
            Alerts.Add(new SecurityAlert
            {
                Message = "检测到异常网络活动",
                ThreatLevel = ThreatLevel.Medium,
                Timestamp = DateTime.Now.AddMinutes(-5),
                Source = "防火墙"
            });

            Alerts.Add(new SecurityAlert
            {
                Message = "未授权访问尝试",
                ThreatLevel = ThreatLevel.High,
                Timestamp = DateTime.Now.AddMinutes(-15),
                Source = "认证系统"
            });

            Alerts.Add(new SecurityAlert
            {
                Message = "可疑的数据包检测",
                ThreatLevel = ThreatLevel.Low,
                Timestamp = DateTime.Now.AddMinutes(-30),
                Source = "网络监控"
            });
        }

        [RelayCommand]
        private void ToggleFirewall()
        {
            IsFirewallEnabled = !IsFirewallEnabled;
        }

        [RelayCommand]
        private void ToggleHackProtection()
        {
            IsHackProtectionEnabled = !IsHackProtectionEnabled;
        }

        [RelayCommand]
        private void ResolveAlert(SecurityAlert alert)
        {
            alert.IsResolved = true;
            UpdateAlertCount();
        }

        [RelayCommand]
        private void ClearAllAlerts()
        {
            Alerts.Clear();
            UpdateAlertCount();
        }

        [RelayCommand]
        private void RunSecurityScan()
        {
            SecurityStatus = "扫描中...";
            // 模拟安全扫描
            Task.Delay(2000).ContinueWith(t => {
                SecurityStatus = "正常";
            });
        }

        private void UpdateAlertCount()
        {
            ActiveAlerts = Alerts.Count(a => !a.IsResolved);
        }
    }
}