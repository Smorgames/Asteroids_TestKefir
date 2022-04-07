using UnityEngine;

namespace Services.AssetProviding
{
    public interface IAssetProvider
    {
        T LoadAsset<T>(string assetPath) where T : Object;
    }
}