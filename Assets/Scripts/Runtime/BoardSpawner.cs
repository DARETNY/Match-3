using Commands;
using Data;
using Signals;
using UnityEngine;
using Zenject;

namespace Runtime
{
    public class BoardSpawner : MonoBehaviour
    {
        [Inject] private SignalBus signalBus;
        [Inject] private BuildBoard buildOn;
        [SerializeField] private BoardData _boardData;

        private void OnEnable()
        {
            signalBus.Subscribe<GameStartedSignal>(OnGameStarted);
            signalBus.Subscribe<ClickExpired>(Onclicktt);
        }

        private void Onclicktt(ClickExpired obj)
        {
            obj.Click++;

            var desiredClick = obj.DesiredClick(10);
            Debug.Log(desiredClick);
        }


        public void OnGameStarted()
        {
            buildOn.CreatBoard(_boardData, transform);
        }

        private void OnDisable()
        {
            signalBus.TryUnsubscribe<GameStartedSignal>(OnGameStarted);
        }


        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                signalBus.TryFire<GameStartedSignal>();
            }

            if (Input.GetMouseButtonDown(0))
            {
                signalBus.TryFire<ClickExpired>();
            }
        }
    }
}