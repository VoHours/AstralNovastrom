using System.ComponentModel;

namespace AstralNovastrom.src.Models
{
    public class ProcessorMetrics : INotifyPropertyChanged
    {
        private double _loadPercentage = 47.0;
        private double _temperature = 42.0;
        private double _memoryIntegrity = 99.7;
        private double _instructionThroughput = 12.5;
        private bool _isOverheating = false;
        private string _status = "Normal";

        public double LoadPercentage
        {
            get => _loadPercentage;
            set
            {
                if (_loadPercentage != value)
                {
                    _loadPercentage = value;
                    OnPropertyChanged(nameof(LoadPercentage));
                    
                    // 更新状�?                    UpdateStatus();
                }
            }
        }

        public double Temperature
        {
            get => _temperature;
            set
            {
                if (_temperature != value)
                {
                    _temperature = value;
                    OnPropertyChanged(nameof(Temperature));
                    
                    // 检查是否过�?                    IsOverheating = _temperature > 120;
                }
            }
        }

        public double MemoryIntegrity
        {
            get => _memoryIntegrity;
            set
            {
                if (_memoryIntegrity != value)
                {
                    _memoryIntegrity = value;
                    OnPropertyChanged(nameof(MemoryIntegrity));
                }
            }
        }

        public double InstructionThroughput
        {
            get => _instructionThroughput;
            set
            {
                if (_instructionThroughput != value)
                {
                    _instructionThroughput = value;
                    OnPropertyChanged(nameof(InstructionThroughput));
                }
            }
        }

        public bool IsOverheating
        {
            get => _isOverheating;
            private set
            {
                if (_isOverheating != value)
                {
                    _isOverheating = value;
                    OnPropertyChanged(nameof(IsOverheating));
                }
            }
        }

        public string Status
        {
            get => _status;
            private set
            {
                if (_status != value)
                {
                    _status = value;
                    OnPropertyChanged(nameof(Status));
                }
            }
        }

        private void UpdateStatus()
        {
            if (_loadPercentage >= 100)
            {
                Status = "Critical";
            }
            else if (_loadPercentage >= 90)
            {
                Status = "Warning";
            }
            else if (_loadPercentage >= 70)
            {
                Status = "High";
            }
            else
            {
                Status = "Normal";
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
