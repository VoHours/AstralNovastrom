using System;
using System.ComponentModel;

namespace AstralNovastrom.Models
{
    public enum LogType
    {
        Info,
        Warning,
        Critical
    }

    public class LogEntry : INotifyPropertyChanged
    {
        private string _message = string.Empty;
        private bool _isGlitching;
        private LogType _type;
        private DateTime _timestamp;

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

        public LogType Type
        {
            get => _type;
            set
            {
                if (_type != value)
                {
                    _type = value;
                    OnPropertyChanged(nameof(Type));
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

        public bool IsGlitching
        {
            get => _isGlitching;
            set
            {
                if (_isGlitching != value)
                {
                    _isGlitching = value;
                    OnPropertyChanged(nameof(IsGlitching));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return $"[{Timestamp:HH:mm:ss}] {Message}";
        }
    }
}