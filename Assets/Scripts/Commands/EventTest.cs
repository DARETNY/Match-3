using System;
using Signals;
using UnityEngine;
using Zenject;

namespace Commands
{
    public class EventTest : IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;


        public EventTest(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }


        public void Initialize()
        {
            _signalBus.Subscribe<GameStartedSignal>(Test);
            _signalBus.Subscribe<ClickExpired>(EnoughClick);
        }

        private void EnoughClick(ClickExpired obj)
        {
            Debug.Log(obj.Click);
        }

        void Test()
        {
            var centerofthescreen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    GameObject newCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    newCube.transform.position = centerofthescreen + new Vector3(i + 0.5f, j + 0.5f, 0);
                }
            }

            // creat a base board     
            Debug.Log("This is a test example");
        }

        public void Dispose()
        {
            _signalBus.TryUnsubscribe<GameStartedSignal>(Test);
            _signalBus.TryUnsubscribe<ClickExpired>(EnoughClick);
        }
    }
}