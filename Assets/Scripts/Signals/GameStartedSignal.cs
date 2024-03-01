using Base.Signal_base;
using UnityEngine;

namespace Signals
{
    public struct GameStartedSignal : ICoreSystem
    {
        public Transform Type { get; set; }
    }
}