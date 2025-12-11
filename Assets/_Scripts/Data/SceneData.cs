using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "SceneData", menuName = "Scriptable Objects/SceneData")]
public class SceneData : ScriptableObject
{
    public SceneInfo SceneInfo;
}

[Serializable]
public struct SceneInfo {
    public string Key;
    public string Name;
    public AssetReferenceT<SceneAsset> Scene;
}

namespace UnityEngine {
    public class SceneAsset : UnityEngine.Object {

    }
}