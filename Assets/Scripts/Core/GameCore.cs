using Commands;
using Core.SignalCore;
using Zenject;

namespace Core
{
    public class GameCore : MonoInstaller
    {
        // ReSharper disable Unity.PerformanceAnalysis
        public override void InstallBindings()
        {
            BoardSignals.Install(Container);

            Container.BindInterfacesAndSelfTo<BuildBoard>().AsSingle();
        }
    }
}