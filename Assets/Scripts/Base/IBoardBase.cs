using Data;
using UnityEngine;

namespace Base
{
    public interface IBoardBase
    {
        bool Isplaying { get; set; }
        void CreatBoard(BoardData data, Transform parent);
    }
}