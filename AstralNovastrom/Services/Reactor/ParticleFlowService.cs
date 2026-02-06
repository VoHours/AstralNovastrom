using System.Timers;

namespace AstralNovastrom.Services.Reactor
{
    public class ParticleFlowService
    {
        private double _particleFlowRate;
        private double _flowStability;
        private double _particleDensity;
        private System.Timers.Timer? _flowTimer;
        private Random _random;

        public event EventHandler<ParticleFlowData>? FlowUpdated;

        public double ParticleFlowRate => _particleFlowRate;
        public double FlowStability => _flowStability;
        public double ParticleDensity => _particleDensity;

        public ParticleFlowService()
        {
            _particleFlowRate = 300.0;
            _flowStability = 0.95;
            _particleDensity = 1.0;
            _random = new Random();
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            _flowTimer = new System.Timers.Timer(500);
            _flowTimer.Elapsed += FlowTimer_Elapsed;
            _flowTimer.Start();
        }

        private void FlowTimer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            UpdateParticleFlow();
            FlowUpdated?.Invoke(this, new ParticleFlowData
            {
                FlowRate = _particleFlowRate,
                Stability = _flowStability,
                Density = _particleDensity
            });
        }

        private void UpdateParticleFlow()
        {
            // 模拟粒子流率变化
            _particleFlowRate += (_random.NextDouble() - 0.5) * 10;
            _particleFlowRate = Math.Max(0, _particleFlowRate);

            // 模拟流稳定性变化
            _flowStability += (_random.NextDouble() - 0.5) * 0.01;
            _flowStability = Math.Max(0, Math.Min(1, _flowStability));

            // 模拟粒子密度变化
            _particleDensity += (_random.NextDouble() - 0.5) * 0.02;
            _particleDensity = Math.Max(0.5, Math.Min(1.5, _particleDensity));
        }

        public void AdjustFlowRate(double targetRate)
        {
            // 实现流量调节逻辑
        }

        public void StabilizeFlow()
        {
            // 实现流量稳定逻辑
        }

        public void Dispose()
        {
            _flowTimer?.Stop();
            _flowTimer?.Dispose();
        }

        public class ParticleFlowData
        {
            public double FlowRate { get; set; }
            public double Stability { get; set; }
            public double Density { get; set; }
        }
    }
}