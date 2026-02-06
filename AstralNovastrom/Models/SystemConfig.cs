using System.ComponentModel;

namespace AstralNovastrom.Models
{
    public class SystemConfig : INotifyPropertyChanged
    {
        private bool _autoStartReactor;
        private bool _enableFirewall;
        private bool _enableHackProtection;
        private bool _enableAutoShutdown;
        private double _criticalTemperatureThreshold;
        private int _logRetentionDays;
        private int _alertRefreshInterval;
        private string _systemName;
        private string _operatorName;

        public bool AutoStartReactor
        {
            get => _autoStartReactor;
            set
            {
                if (_autoStartReactor != value)
                {
                    _autoStartReactor = value;
                    OnPropertyChanged(nameof(AutoStartReactor));
                }
            }
        }

        public bool EnableFirewall
        {
            get => _enableFirewall;
            set
            {
                if (_enableFirewall != value)
                {
                    _enableFirewall = value;
                    OnPropertyChanged(nameof(EnableFirewall));
                }
            }
        }

        public bool EnableHackProtection
        {
            get => _enableHackProtection;
            set
            {
                if (_enableHackProtection != value)
                {
                    _enableHackProtection = value;
                    OnPropertyChanged(nameof(EnableHackProtection));
                }
            }
        }

        public bool EnableAutoShutdown
        {
            get => _enableAutoShutdown;
            set
            {
                if (_enableAutoShutdown != value)
                {
                    _enableAutoShutdown = value;
                    OnPropertyChanged(nameof(EnableAutoShutdown));
                }
            }
        }

        public double CriticalTemperatureThreshold
        {
            get => _criticalTemperatureThreshold;
            set
            {
                if (_criticalTemperatureThreshold != value)
                {
                    _criticalTemperatureThreshold = value;
                    OnPropertyChanged(nameof(CriticalTemperatureThreshold));
                }
            }
        }

        public int LogRetentionDays
        {
            get => _logRetentionDays;
            set
            {
                if (_logRetentionDays != value)
                {
                    _logRetentionDays = value;
                    OnPropertyChanged(nameof(LogRetentionDays));
                }
            }
        }

        public int AlertRefreshInterval
        {
            get => _alertRefreshInterval;
            set
            {
                if (_alertRefreshInterval != value)
                {
                    _alertRefreshInterval = value;
                    OnPropertyChanged(nameof(AlertRefreshInterval));
                }
            }
        }

        public string SystemName
        {
            get => _systemName;
            set
            {
                if (_systemName != value)
                {
                    _systemName = value;
                    OnPropertyChanged(nameof(SystemName));
                }
            }
        }

        public string OperatorName
        {
            get => _operatorName;
            set
            {
                if (_operatorName != value)
                {
                    _operatorName = value;
                    OnPropertyChanged(nameof(OperatorName));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public SystemConfig()
        {
            // 默认配置
            _autoStartReactor = false;
            _enableFirewall = true;
            _enableHackProtection = true;
            _enableAutoShutdown = true;
            _criticalTemperatureThreshold = 120.0;
            _logRetentionDays = 30;
            _alertRefreshInterval = 5;
            _systemName = "Astral Novastrom";
            _operatorName = "System";
        }
    }
}