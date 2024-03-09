using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace OskaKim.Presentations.Sample.Sea
{
    public class SeaPreloader
    {
        private const string MyShipAddress = "Assets/ExternalResources/Sample/Character.prefab";

        private Dictionary<string, AsyncOperationHandle<GameObject>> handleCacheDic = new();
        public GameObject MyShipPrefab { get; private set; }

        public async UniTask LoadPrefabs()
        {
            MyShipPrefab = await LoadPrefabAsync(MyShipAddress);
        }

        public void Dispose()
        {
            foreach (var handle in handleCacheDic.Values)
            {
                Addressables.Release(handle);
            }
        }

        // TODO : 범용화
        private AsyncOperationHandle<GameObject> LoadPrefabAsync(string address)
        {
            if (handleCacheDic.TryGetValue(address, out var cachedHandle)) return cachedHandle;
            var handle = Addressables.LoadAssetAsync<GameObject>(address);
            handleCacheDic.Add(address, handle);
            return handle;
        }
    }
}
