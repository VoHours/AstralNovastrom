using AstralNovastrom.Models;
using System.Timers;
using System.Threading.Tasks;

namespace AstralNovastrom.Services.Reactor
{
    public class ReactorSimulationService
    {
        private ReactorStatus _reactorStatus;
        private System.Timers.Timer? _simulationTimer;
        private Random _random;

        public event EventHandler<ReactorStatus>? StatusUpdated;

        public ReactorSimulationService()
        {
            _reactorStatus = new ReactorStatus();
            _random = new Random();
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            _simulationTimer = new System.Timers.Timer(1000);
            _simulationTimer.Elapsed += SimulationTimer_Elapsed;
            _simulationTimer.Start();
        }

        private void SimulationTimer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            UpdateReactorStatus();
            StatusUpdated?.Invoke(this, _reactorStatus);
        }

        private void UpdateReactorStatus()
        {
            // 模拟PSI稳定性变化
            _reactorStatus.PsiStability += (_random.NextDouble() - 0.5) * 0.1;
            _reactorStatus.PsiStability = Math.Max(0, Math.Min(10, _reactorStatus.PsiStability));

            // 模拟提取效率变化
            _reactorStatus.ExtractionEfficiency += (_random.NextDouble() - 0.5) * 0.5;
            _reactorStatus.ExtractionEfficiency = Math.Max(0, Math.Min(100, _reactorStatus.ExtractionEfficiency));

            // 模拟粒子流率变化
            _reactorStatus.ParticleFlowRate += (_random.NextDouble() - 0.5) * 10;
            _reactorStatus.ParticleFlowRate = Math.Max(0, _reactorStatus.ParticleFlowRate);

            // 模拟能量输出变化
            _reactorStatus.EnergyOutput += (_random.NextDouble() - 0.5) * 50;
            _reactorStatus.EnergyOutput = Math.Max(0, _reactorStatus.EnergyOutput);

            // 更新稳定性状态
            _reactorStatus.IsStable = _reactorStatus.PsiStability > 5 && _reactorStatus.ExtractionEfficiency > 70;

            // 更新当前模式
            if (!_reactorStatus.IsStable)
                _reactorStatus.CurrentMode = "不稳定";
            else if (_reactorStatus.ExtractionEfficiency > 90)
                _reactorStatus.CurrentMode = "高效";
            else
                _reactorStatus.CurrentMode = "正常";
        }

        public ReactorStatus GetCurrentStatus()
        {
            return _reactorStatus;
        }

        public void StartReactor()
        {
            _reactorStatus.CurrentMode = "启动中";
            // 模拟启动过程
            Task.Delay(3000).ContinueWith(t =>
            {
                _reactorStatus.CurrentMode = "正常";
            });
        }

        public void StopReactor()
        {
            _reactorStatus.CurrentMode = "停止中";
            // 模拟停止过程
            Task.Delay(2000).ContinueWith(t =>
            {
                _reactorStatus.CurrentMode = "已停止";
                _reactorStatus.PsiStability = 0;
                _reactorStatus.ExtractionEfficiency = 0;
                _reactorStatus.ParticleFlowRate = 0;
                _reactorStatus.EnergyOutput = 0;
                _reactorStatus.IsStable = false;
            });
        }

        public void SetPowerLevel(double level)
        {
            // 实现功率调节逻辑
        }

        public void Dispose()
        {
            _simulationTimer?.Stop();
            _simulationTimer?.Dispose();
        }
    }
}