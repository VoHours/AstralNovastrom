using System.ComponentModel;

namespace AstralNovastrom.Models
{
    public class ReactorStatus : INotifyPropertyChanged
    {
        private double _psiStability = 7.2;
        private double _extractionEfficiency = 87.2;
        private double _particleFlowRate = 320.5;
        private double _energyOutput = 1500.0;
        private bool _isStable = true;
        private string _currentMode = "Normal";

        public double PsiStability
        {
            get => _psiStability;
            set
            {
                if (_psiStability != value)
                {
                    _psiStability = value;
                    OnPropertyChanged(nameof(PsiStability));
                }
            }
        }

        public double ExtractionEfficiency
        {
            get => _extractionEfficiency;
            set
            {
                if (_extractionEfficiency != value)
                {
                    _extractionEfficiency = value;
                    OnPropertyChanged(nameof(ExtractionEfficiency));
                }
            }
        }

        public double ParticleFlowRate
        {
            get => _particleFlowRate;
            set
            {
                if (_particleFlowRate != value)
                {
                    _particleFlowRate = value;
                    OnPropertyChanged(nameof(ParticleFlowRate));
                }
            }
        }

        public double EnergyOutput
        {
            get => _energyOutput;
            set
            {
                if (_energyOutput != value)
                {
                    _energyOutput = value;
                    OnPropertyChanged(nameof(EnergyOutput));
                }
            }
        }

        public bool IsStable
        {
            get => _isStable;
            set
            {
                if (_isStable != value)
                {
                    _isStable = value;
                    OnPropertyChanged(nameof(IsStable));
                }
            }
        }

        public string CurrentMode
        {
            get => _currentMode;
            set
            {
                if (_currentMode != value)
                {
                    _currentMode = value;
                    OnPropertyChanged(nameof(CurrentMode));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}