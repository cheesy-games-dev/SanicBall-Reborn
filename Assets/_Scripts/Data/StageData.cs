using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Sanicball.Data
{
    [System.Serializable]
    public class StageData
    {
        public string name;
        public int id;
        public SceneReference scene;
        public Sprite picture;
        public GameObject overviewPrefab;
    }

    [Serializable]
    public class SceneReference : AssetReference {
        public override bool ValidateAsset(string path) {
            return path.Contains(".unity");
        }
    }
}
