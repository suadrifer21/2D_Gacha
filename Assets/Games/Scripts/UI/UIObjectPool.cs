using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIObjectPool : MonoBehaviour
{
    [SerializeField] private AddressableController addressableController;
    [SerializeField] private List<ItemObjectUI> pooledProcessItemUI;    
    [SerializeField] private ItemObjectUI objectToPool;
    [SerializeField] private Transform processItemUIParent;
    [SerializeField] private int amountToPool;
    private Vector3 defaultObjectScale;
    public Vector3 DefaultObjectScale { get; }
        
    private void Start()
    {
        addressableController.ItemOBjectUILoadedEvent += SetObjectToPool;
    }

    private void SetObjectToPool(GameObject g)
    {
        if (g != null)
        {
            objectToPool = g.GetComponent<ItemObjectUI>();
        }

        GeneratePool();
    }

    private void GeneratePool()
    {
        defaultObjectScale = objectToPool.GetComponent<RectTransform>().localScale;

        ItemObjectUI itemObjectUI;
        for (int i = 0; i < amountToPool; i++)
        {
            itemObjectUI = Instantiate(objectToPool);
            itemObjectUI.transform.SetParent(processItemUIParent, false);
            itemObjectUI.gameObject.SetActive(false);
            pooledProcessItemUI.Add(itemObjectUI);
        }
    }

    public ItemObjectUI GetPooledProcessItemUI()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledProcessItemUI[i].gameObject.activeInHierarchy)
            {
                return pooledProcessItemUI[i];
            }
        }
        return null;
    }
}
