using UnityEngine;

namespace Services.AssetProviding
{
    public class AssetProvider : IAssetProvider
    {
        public T LoadAsset<T>(string assetPath) where T : Object => 
            Resources.Load<T>(assetPath);
    }
}