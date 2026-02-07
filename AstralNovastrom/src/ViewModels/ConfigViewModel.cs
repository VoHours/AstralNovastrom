using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AstralNovastrom.src.Models;

namespace AstralNovastrom.src.ViewModels
{
    public partial class ConfigViewModel : ObservableObject
    {
        public SystemConfig SystemConfig { get; set; }

        [ObservableProperty]
        private bool _isAutoStartReactor;

        [ObservableProperty]
        private bool _isEnableFirewall;

        [ObservableProperty]
        private bool _isEnableHackProtection;

        [ObservableProperty]
        private bool _isEnableAutoShutdown;

        [ObservableProperty]
        private double _criticalTemperatureThreshold;

        [ObservableProperty]
        private int _logRetentionDays;

        [ObservableProperty]
        private int _alertRefreshInterval;

        [ObservableProperty]
        private string _systemName = string.Empty;

        [ObservableProperty]
        private string _operatorName = string.Empty;

        public ConfigViewModel()
        {
            SystemConfig = new SystemConfig();
            LoadConfig();
        }

        private void LoadConfig()
        {
            // 加载配置
            IsAutoStartReactor = SystemConfig.AutoStartReactor;
            IsEnableFirewall = SystemConfig.EnableFirewall;
            IsEnableHackProtection = SystemConfig.EnableHackProtection;
            IsEnableAutoShutdown = SystemConfig.EnableAutoShutdown;
            CriticalTemperatureThreshold = SystemConfig.CriticalTemperatureThreshold;
            LogRetentionDays = SystemConfig.LogRetentionDays;
            AlertRefreshInterval = SystemConfig.AlertRefreshInterval;
            SystemName = SystemConfig.SystemName;
            OperatorName = SystemConfig.OperatorName;
        }

        [RelayCommand]
        private void SaveConfig()
        {
            // 保存配置
            SystemConfig.AutoStartReactor = IsAutoStartReactor;
            SystemConfig.EnableFirewall = IsEnableFirewall;
            SystemConfig.EnableHackProtection = IsEnableHackProtection;
            SystemConfig.EnableAutoShutdown = IsEnableAutoShutdown;
            SystemConfig.CriticalTemperatureThreshold = CriticalTemperatureThreshold;
            SystemConfig.LogRetentionDays = LogRetentionDays;
            SystemConfig.AlertRefreshInterval = AlertRefreshInterval;
            SystemConfig.SystemName = SystemName;
            SystemConfig.OperatorName = OperatorName;

            // 实现配置保存逻辑
        }

        [RelayCommand]
        private void ResetToDefaults()
        {
            SystemConfig = new SystemConfig();
            LoadConfig();
        }

        [RelayCommand]
        private void ExportConfig()
        {
            // 实现配置导出逻辑
        }

        [RelayCommand]
        private void ImportConfig()
        {
            // 实现配置导入逻辑
        }
    }
}
