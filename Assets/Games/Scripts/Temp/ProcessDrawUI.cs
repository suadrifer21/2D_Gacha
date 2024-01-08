using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessDrawUI : DrawUI
{
    [SerializeField] private ItemObjectUI itemObjectUI;

    // Start is called before the first frame update
    void Start()
    {
        //ProcessDrawState.DrawDataEvent += itemObjectUI.SetData;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDisable()
    {
        //ProcessDrawState.DrawDataEvent -= itemObjectUI.SetData;
    }
}
