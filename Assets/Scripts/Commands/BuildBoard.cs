using Base;
using Data;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Commands
{
    public class BuildBoard : IBoardBase
    {
        readonly Camera _mainCamera = Camera.main;

        GameObject _basement;

        [ShowInInspector, FoldoutGroup("Settings")]
        public bool Isplaying { get; set; }

        public void CreatBoard(BoardData data, Transform parent)
        {
            if (Isplaying)
                return;
            for (var y = 0; y < data.height; y++)
            {
                for (var x = 0; x < data.width; x++)
                {
                    //todo:Find gameobjects waryant
                    _basement = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Square"),
                        new Vector3(x * data.offset, y * data.offset, 0),
                        Quaternion.identity, parent) as GameObject;

                    _basement.name = $"Tile ({x},{y})";
                }
            }

            Isplaying = true;
            ApplyCamera(data);
        }

        public void ClearAllBoard(Transform parent)
        {
            if (!Isplaying)
                return;

            for (var i = 0; i < parent.childCount; i++)
            {
                Object.Destroy(parent.GetChild(i).gameObject);
            }

            Isplaying = false;
        }
       

        private void ApplyCamera(BoardData data)
        {
            if (_mainCamera is null) return;

            var halfWidth = ((float)data.width - 1) * .5f * data.offset;
            var halfHeight = ((float)data.height - 1) * .5f * data.offset;
            _mainCamera.transform.position = new Vector3(halfWidth, halfHeight, -10f);

            var aspectRatio = (float)Screen.width / Screen.height;
            var verticalSize = data.height + data.offset / aspectRatio;
            var horizontalSize = (data.width + data.offset) / aspectRatio;
            _mainCamera.orthographicSize = (verticalSize > horizontalSize) ? verticalSize : horizontalSize;
        }
    }
}