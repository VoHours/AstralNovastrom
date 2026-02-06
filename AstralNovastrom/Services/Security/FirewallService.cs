using System.Timers;

namespace AstralNovastrom.Services.Security
{
    public class FirewallService
    {
        private bool _isEnabled;
        private int _blockedAttempts;
        private int _allowedConnections;
        private System.Timers.Timer? _firewallTimer;
        private Random _random;

        public event EventHandler<FirewallStatus>? StatusUpdated;

        public bool IsEnabled => _isEnabled;
        public int BlockedAttempts => _blockedAttempts;
        public int AllowedConnections => _allowedConnections;

        public FirewallService()
        {
            _isEnabled = true;
            _blockedAttempts = 0;
            _allowedConnections = 0;
            _random = new Random();
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            _firewallTimer = new System.Timers.Timer(2000);
            _firewallTimer.Elapsed += FirewallTimer_Elapsed;
            _firewallTimer.Start();
        }

        private void FirewallTimer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            if (_isEnabled)
            {
                SimulateFirewallActivity();
            }

            StatusUpdated?.Invoke(this, new FirewallStatus
            {
                IsEnabled = _isEnabled,
                BlockedAttempts = _blockedAttempts,
                AllowedConnections = _allowedConnections
            });
        }

        private void SimulateFirewallActivity()
        {
            // 模拟防火墙活动
            if (_random.NextDouble() < 0.6) // 60% 概率有连接尝试
            {
                if (_random.NextDouble() < 0.2) // 20% 概率被阻止
                {
                    _blockedAttempts++;
                }
                else
                {
                    _allowedConnections++;
                }
            }
        }

        public void EnableFirewall()
        {
            _isEnabled = true;
        }

        public void DisableFirewall()
        {
            _isEnabled = false;
        }

        public void ResetCounters()
        {
            _blockedAttempts = 0;
            _allowedConnections = 0;
        }

        public void BlockIp(string ipAddress)
        {
            // 实现IP封锁逻辑
        }

        public void AllowIp(string ipAddress)
        {
            // 实现IP允许逻辑
        }

        public void Dispose()
        {
            _firewallTimer?.Stop();
            _firewallTimer?.Dispose();
        }

        public class FirewallStatus
        {
            public bool IsEnabled { get; set; }
            public int BlockedAttempts { get; set; }
            public int AllowedConnections { get; set; }
        }
    }
}