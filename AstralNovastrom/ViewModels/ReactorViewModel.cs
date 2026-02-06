using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AstralNovastrom.Models;
using System.Windows.Threading;

namespace AstralNovastrom.ViewModels
{
    public partial class ReactorViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool _isReactorRunning = true;

        [ObservableProperty]
        private string _reactorMode = "正常";

        [ObservableProperty]
        private double _psiStability = 7.2;

        [ObservableProperty]
        private double _extractionEfficiency = 87.2;

        [ObservableProperty]
        private double _particleFlowRate = 320.5;

        [ObservableProperty]
        private double _energyOutput = 1500.0;

        public ReactorStatus ReactorStatus { get; set; }

        private DispatcherTimer? _updateTimer;

        public ReactorViewModel()
        {
            ReactorStatus = new ReactorStatus();
            InitializeTimer();
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
            PsiStability = 7.0 + Math.Sin(DateTime.Now.Ticks * 0.0001) * 0.5;
            ExtractionEfficiency = 85.0 + Math.Sin(DateTime.Now.Ticks * 0.0002) * 5.0;
            ParticleFlowRate = 300.0 + Math.Sin(DateTime.Now.Ticks * 0.0003) * 50.0;
            EnergyOutput = 1400.0 + Math.Sin(DateTime.Now.Ticks * 0.0004) * 200.0;

            // 更新反应堆状态
            ReactorStatus.PsiStability = PsiStability;
            ReactorStatus.ExtractionEfficiency = ExtractionEfficiency;
            ReactorStatus.ParticleFlowRate = ParticleFlowRate;
            ReactorStatus.EnergyOutput = EnergyOutput;
        }

        [RelayCommand]
        private void StartReactor()
        {
            IsReactorRunning = true;
            ReactorMode = "正常";
        }

        [RelayCommand]
        private void StopReactor()
        {
            IsReactorRunning = false;
            ReactorMode = "停止";
        }

        [RelayCommand]
        private void SetReactorMode(string mode)
        {
            ReactorMode = mode;
            // 实现模式切换逻辑
        }

        [RelayCommand]
        private void EmergencyShutdown()
        {
            IsReactorRunning = false;
            ReactorMode = "紧急停止";
            // 实现紧急停机逻辑
        }
    }
}