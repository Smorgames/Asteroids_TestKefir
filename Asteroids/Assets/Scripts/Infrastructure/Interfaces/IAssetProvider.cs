using UnityEngine;

namespace Infrastructure.Interfaces
{
    public interface IAssetProvider
    {
        T LoadAsset<T>(string assetPath) where T : Object;
    }
}