using AstralNovastrom.Models;
using System.Timers;

namespace AstralNovastrom.Services.Security
{
    public class ThreatDetectionService
    {
        private System.Timers.Timer? _detectionTimer;
        private Random _random;
        private List<SecurityAlert> _detectedThreats;

        public event EventHandler<SecurityAlert>? ThreatDetected;

        public List<SecurityAlert> DetectedThreats => _detectedThreats;

        public ThreatDetectionService()
        {
            _detectedThreats = new List<SecurityAlert>();
            _random = new Random();
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            _detectionTimer = new System.Timers.Timer(5000);
            _detectionTimer.Elapsed += DetectionTimer_Elapsed;
            _detectionTimer.Start();
        }

        private void DetectionTimer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            DetectThreats();
        }

        private void DetectThreats()
        {
            // 模拟威胁检测
            if (_random.NextDouble() < 0.3) // 30% 概率检测到威胁
            {
                var threatLevel = (ThreatLevel)_random.Next(4);
                var alert = new SecurityAlert
                {
                    Message = GetRandomThreatMessage(threatLevel),
                    ThreatLevel = threatLevel,
                    Source = "威胁检测系统"
                };

                _detectedThreats.Add(alert);
                ThreatDetected?.Invoke(this, alert);
            }
        }

        private string GetRandomThreatMessage(ThreatLevel level)
        {
            string[] lowThreats = {
                "检测到可疑的网络请求",
                "发现异常的系统调用",
                "检测到轻微的网络流量异常"
            };

            string[] mediumThreats = {
                "检测到未授权的访问尝试",
                "发现可疑的数据包",
                "检测到异常的处理器活动"
            };

            string[] highThreats = {
                "检测到可能的入侵尝试",
                "发现恶意代码签名",
                "检测到大量的未授权访问尝试"
            };

            string[] criticalThreats = {
                "检测到严重的安全漏洞利用",
                "发现系统被入侵的迹象",
                "检测到数据泄露尝试"
            };

            switch (level)
            {
                case ThreatLevel.Low:
                    return lowThreats[_random.Next(lowThreats.Length)];
                case ThreatLevel.Medium:
                    return mediumThreats[_random.Next(mediumThreats.Length)];
                case ThreatLevel.High:
                    return highThreats[_random.Next(highThreats.Length)];
                case ThreatLevel.Critical:
                    return criticalThreats[_random.Next(criticalThreats.Length)];
                default:
                    return "检测到未知威胁";
            }
        }

        public void ScanForThreats()
        {
            // 手动扫描威胁
            DetectThreats();
        }

        public void ResolveThreat(SecurityAlert alert)
        {
            _detectedThreats.Remove(alert);
        }

        public void ClearAllThreats()
        {
            _detectedThreats.Clear();
        }

        public void Dispose()
        {
            _detectionTimer?.Stop();
            _detectionTimer?.Dispose();
        }
    }
}