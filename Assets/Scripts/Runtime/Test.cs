using Signals;
using UnityEngine;
using Zenject;

namespace Runtime
{
    public class Test : MonoBehaviour
    {
        [Inject] SignalBus _signalBus;
        private ClickExpired _clickExpired;

        private void Start()
        {
            _clickExpired.Click = 0;
            _signalBus.TryFire<GameStartedSignal>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space)&& _signalBus.IsSignalDeclared<GameStartedSignal>())
            {
                _clickExpired.Click++;
                _signalBus.TryFire(_clickExpired);
                Debug.Log(_clickExpired.DesiredClick(20));
            }
        }
    }
}