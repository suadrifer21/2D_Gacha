using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DrawUI : MonoBehaviour
{ 
    [SerializeField] private GameObject ItemObjectUI;
    public void ToggleUI(bool isEnabled)
    {
        ItemObjectUI.SetActive(isEnabled);
    }
}
