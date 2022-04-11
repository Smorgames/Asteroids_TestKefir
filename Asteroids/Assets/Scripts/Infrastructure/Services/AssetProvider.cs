using Infrastructure.Interfaces;
using UnityEngine;

namespace Infrastructure.Services
{
    public class AssetProvider : IAssetProvider
    {
        public T LoadAsset<T>(string assetPath) where T : Object => 
            Resources.Load<T>(assetPath);
    }
}