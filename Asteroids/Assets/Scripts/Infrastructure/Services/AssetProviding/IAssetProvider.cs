using UnityEngine;

namespace Infrastructure.Services.AssetProviding
{
    public interface IAssetProvider
    {
        T LoadAsset<T>(string assetPath) where T : Object;
    }
}