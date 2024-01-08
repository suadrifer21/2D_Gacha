using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System;

public class AddressableController : MonoBehaviour
{
    [SerializeField] AssetReferenceGameObject itemObjectUIReference;

    private GameObject itemObjectUIPrefabs;

    public event Action<GameObject> ItemOBjectUILoadedEvent;

    private void Start()
    {
        itemObjectUIReference.LoadAssetAsync().Completed += OnItemOBjectUILoaded;
    }
    private void OnItemOBjectUILoaded(AsyncOperationHandle<GameObject> handle)
    {
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            itemObjectUIPrefabs = handle.Result;
            ItemOBjectUILoadedEvent?.Invoke(itemObjectUIPrefabs);
        }
        else
        {
            ItemOBjectUILoadedEvent?.Invoke(null);
            Debug.LogError("Loading itemObjectUI Asset Failed");
        }
    }
}
