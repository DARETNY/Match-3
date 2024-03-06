using System;
using Sirenix.OdinInspector;

namespace Data
{
    [Serializable]
    public struct BoardData
    {
        [FoldoutGroup("Settings")] public float offset;

        [TabGroup("basement")] public int width;
        [TabGroup("basement")] public int height;
    }
}