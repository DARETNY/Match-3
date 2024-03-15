using Signals;
using Zenject;

namespace Core.SignalCore
{
    /// <summary>
    /// this class only responsible to declare signals
    /// </summary>
    public class BoardSignals : Installer<BoardSignals>
    {
        // ReSharper disable Unity.PerformanceAnalysis
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);

            Container.DeclareSignal<GameStartedSignal>();
            Container.DeclareSignal<ClickExpired>();

        }
    }
}