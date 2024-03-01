using Commands;
using Signals;
using Zenject;

namespace Core
{
    public class SignalCore : MonoInstaller<SignalCore>
    {
        // ReSharper disable Unity.PerformanceAnalysis
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
            Container.DeclareSignal<GameStartedSignal>().RequireSubscriber();
            Container.DeclareSignal<ClickExpired>().RequireSubscriber();
            Container.BindInterfacesAndSelfTo<EventTest>().AsTransient();
            
        }
    }
}