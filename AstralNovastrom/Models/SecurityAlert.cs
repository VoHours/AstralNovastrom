using System;
using System.ComponentModel;

namespace AstralNovastrom.Models
{
    public enum ThreatLevel
    {
        Low,
        Medium,
        High,
        Critical
    }

    public class SecurityAlert : INotifyPropertyChanged
    {
        private string _alertId = string.Empty;
        private string _message = string.Empty;
        private ThreatLevel _threatLevel;
        private DateTime _timestamp;
        private bool _isResolved;
        private string _source = string.Empty;

        public string AlertId
        {
            get => _alertId;
            set
            {
                if (_alertId != value)
                {
                    _alertId = value;
                    OnPropertyChanged(nameof(AlertId));
                }
            }
        }

        public string Message
        {
            get => _message;
            set
            {
                if (_message != value)
                {
                    _message = value;
                    OnPropertyChanged(nameof(Message));
                }
            }
        }

        public ThreatLevel ThreatLevel
        {
            get => _threatLevel;
            set
            {
                if (_threatLevel != value)
                {
                    _threatLevel = value;
                    OnPropertyChanged(nameof(ThreatLevel));
                }
            }
        }

        public DateTime Timestamp
        {
            get => _timestamp;
            set
            {
                if (_timestamp != value)
                {
                    _timestamp = value;
                    OnPropertyChanged(nameof(Timestamp));
                }
            }
        }

        public bool IsResolved
        {
            get => _isResolved;
            set
            {
                if (_isResolved != value)
                {
                    _isResolved = value;
                    OnPropertyChanged(nameof(IsResolved));
                }
            }
        }

        public string Source
        {
            get => _source;
            set
            {
                if (_source != value)
                {
                    _source = value;
                    OnPropertyChanged(nameof(Source));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public SecurityAlert()
        {
            _alertId = Guid.NewGuid().ToString();
            _timestamp = DateTime.Now;
            _isResolved = false;
        }
    }
}