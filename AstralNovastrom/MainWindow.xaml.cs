using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using AstralNovastrom.src.Controls;
using AstralNovastrom.src.Models;

namespace AstralNovastrom
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<LogEntry> _logEntries = new ObservableCollection<LogEntry>();
        private System.Windows.Threading.DispatcherTimer _logTimer = new System.Windows.Threading.DispatcherTimer();
        private System.Windows.Threading.DispatcherTimer _waveformTimer = new System.Windows.Threading.DispatcherTimer();
        private Random _random = new Random();
        private int _attackPhase = 0;
        private double _processorLoad = 47.0;

        public ObservableCollection<LogEntry> LogEntries
        {
            get => _logEntries;
            set
            {
                _logEntries = value;
                OnPropertyChanged();
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            InitializeLogSystem();
            InitializeWaveform();
            StartSimulations();

            // 设置数据上下文
            DataContext = this;
        }

        private void InitializeLogSystem()
        {
            LogEntries = new ObservableCollection<LogEntry>
            {
                new LogEntry {
                    Message = "[INFO] 系统启动完成 - 时间戳: 5067-Ψ-42.8.15:32:47",
                    Type = LogType.Info,
                    Timestamp = DateTime.Now
                },
                new LogEntry {
                    Message = "[INFO] 量子初始化检查 ... 100% (成功)",
                    Type = LogType.Info,
                    Timestamp = DateTime.Now.AddSeconds(1)
                },
                new LogEntry {
                    Message = "[INFO] Ψ-场稳定在 Ψ-3 级。提取效率：87.2%",
                    Type = LogType.Info,
                    Timestamp = DateTime.Now.AddSeconds(2)
                },
                new LogEntry {
                    Message = "[INFO] 向'天仓五殖民地'输送量子能量包...确认",
                    Type = LogType.Info,
                    Timestamp = DateTime.Now.AddSeconds(3)
                },
                new LogEntry {
                    Message = "[INFO] 火核处理器负载: 47% | 温度: 42°C | 内存: 99.7%",
                    Type = LogType.Info,
                    Timestamp = DateTime.Now.AddSeconds(4)
                }
            };
        }

        private void InitializeWaveform()
        {
            // 波形初始化 - 现在由 QuantumWaveformControl 管理
        }

        private void StartSimulations()
        {
            // 日志事件模拟
            _logTimer = new System.Windows.Threading.DispatcherTimer();
            _logTimer.Interval = TimeSpan.FromSeconds(3);
            _logTimer.Tick += SimulateLogEvents;
            _logTimer.Start();

            // 波形动画 - 现在由 QuantumWaveformControl 管理
            // 威胁级别动画 - 现在由 SystemMonitoringControl 管理
        }

        private void SimulateLogEvents(object? sender, EventArgs e)
        {
            _attackPhase++;

            switch (_attackPhase)
            {
                case 1:
                    AddLogEntry("[WARN] 检测到异常Ψ粒子信号嗅探 ... 来源：未知 (协议7B)", LogType.Warning);
                    StartWarningAnimation();
                    break;

                case 2:
                    AddLogEntry("[WARN] 量子网络接口收到畸形数据包 ... 已隔离丢弃", LogType.Warning);
                    UpdateProcessorLoad(65);
                    break;

                case 3:
                    AddLogEntry("[SECURITY] 在量子脚本框架检测到未签名执行尝试", LogType.Warning);
                    UpdateProcessorLoad(78);
                    break;

                case 4:
                    AddLogEntry("[ERROR] 量子核心模块异常 security_core", LogType.Critical, true);
                    UpdateProcessorLoad(92);
                    StartCriticalAnimation();
                    break;

                case 5:
                    AddLogEntry("[CRITICAL] 火核处理器负载...98%...温度...危险", LogType.Critical, true);
                    UpdateProcessorLoad(98);
                    break;

                case 6:
                    AddLogEntry("[SYSTEM] 处理器温度：127°C 超载临界！ 冷却...无响应", LogType.Critical, true);
                    _attackPhase = 0;
                    ResetSystem();
                    break;
            }

            // 滚动到底部 - 现在由 SystemLogControl 管理
        }

        private void AddLogEntry(string message, LogType type, bool isGlitching = false)
        {
            Dispatcher.BeginInvoke(() =>
            {
                var entry = new LogEntry
                {
                    Message = message,
                    Type = type,
                    Timestamp = DateTime.Now,
                    IsGlitching = isGlitching
                };

                LogEntries.Add(entry);

                // 保持日志数量
                if (LogEntries.Count > 100)
                {
                    LogEntries.RemoveAt(0);
                }
            });
        }

        // UpdateWaveform 方法已移至 QuantumWaveformControl

        private void UpdateProcessorLoad(double newLoad)
        {
            _processorLoad = newLoad;

            // 处理器负载更新 - 现在由 SystemMonitoringControl 管理
        }

        private void StartWarningAnimation()
        {
            // 警告动画 - 现在由 SystemMonitoringControl 管理
        }

        private void StartCriticalAnimation()
        {
            // 临界动画 - 现在由 SystemMonitoringControl 管理
        }

        private void ResetSystem()
        {
            Dispatcher.BeginInvoke(() =>
            {
                _attackPhase = 0;
                UpdateProcessorLoad(47);

                // 重置动画 - 现在由 SystemMonitoringControl 管理

                // 添加恢复日志
                AddLogEntry("[INFO] 系统恢复协议启动 ... 正在稳定量子场", LogType.Info);
                AddLogEntry("[INFO] 火核处理器负载恢复正常: 47%", LogType.Info);
            });
        }

        private void CloseFloatingWindow_Click(object sender, RoutedEventArgs e)
        {
            // FloatingConfigWindow已移至src/Controls文件夹
        }

        // 窗口拖动
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        public event System.ComponentModel.PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }

        private void QuantumWaveformControl_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}