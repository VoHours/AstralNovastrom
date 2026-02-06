using System.Timers;

namespace AstralNovastrom.Services.Reactor
{
    public class EnergyExtractionService
    {
        private double _extractionEfficiency;
        private double _energyOutput;
        private double _energyStorage;
        private System.Timers.Timer? _extractionTimer;
        private Random _random;

        public event EventHandler<EnergyExtractionData>? ExtractionUpdated;

        public double ExtractionEfficiency => _extractionEfficiency;
        public double EnergyOutput => _energyOutput;
        public double EnergyStorage => _energyStorage;

        public EnergyExtractionService()
        {
            _extractionEfficiency = 85.0;
            _energyOutput = 1500.0;
            _energyStorage = 5000.0;
            _random = new Random();
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            _extractionTimer = new System.Timers.Timer(1000);
            _extractionTimer.Elapsed += ExtractionTimer_Elapsed;
            _extractionTimer.Start();
        }

        private void ExtractionTimer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            UpdateEnergyExtraction();
            ExtractionUpdated?.Invoke(this, new EnergyExtractionData
            {
                Efficiency = _extractionEfficiency,
                Output = _energyOutput,
                Storage = _energyStorage
            });
        }

        private void UpdateEnergyExtraction()
        {
            // 模拟提取效率变化
            _extractionEfficiency += (_random.NextDouble() - 0.5) * 0.5;
            _extractionEfficiency = Math.Max(0, Math.Min(100, _extractionEfficiency));

            // 模拟能量输出变化
            _energyOutput = 1000 + (_extractionEfficiency - 50) * 10;
            _energyOutput += (_random.NextDouble() - 0.5) * 100;
            _energyOutput = Math.Max(0, _energyOutput);

            // 模拟能量存储变化
            _energyStorage += _energyOutput * 0.1;
            _energyStorage = Math.Min(10000, _energyStorage);
        }

        public void AdjustExtractionRate(double rate)
        {
            // 实现提取率调节逻辑
        }

        public void OptimizeEfficiency()
        {
            // 实现效率优化逻辑
        }

        public void DischargeEnergy(double amount)
        {
            _energyStorage -= amount;
            _energyStorage = Math.Max(0, _energyStorage);
        }

        public void Dispose()
        {
            _extractionTimer?.Stop();
            _extractionTimer?.Dispose();
        }

        public class EnergyExtractionData
        {
            public double Efficiency { get; set; }
            public double Output { get; set; }
            public double Storage { get; set; }
        }
    }
}