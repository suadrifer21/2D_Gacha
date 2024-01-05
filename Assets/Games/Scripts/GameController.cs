using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    [SerializeField] private GameObject readyDrawCanvas;
    [SerializeField] private GameObject processDrawCanvas;
    [SerializeField] private GameObject resultDrawCanvas;

    private StateMachine stateMachine;

    private DrawController drawController;

    public event Action<bool> DrawEvent;
    private bool isSingleDraw;
    public bool IsSingleDraw { get => isSingleDraw; }

    //test
    public ItemObjectUI itemObjectUI;
    public Transform drawResultUIParent;
    public ItemDetailUI itemDetailUI;

    private void Start()
    {
        drawController = GetComponent<DrawController>();

        stateMachine = new StateMachine(this);
        stateMachine.Initialize(stateMachine.readyDrawState);        
    }
    private void Update()
    {
        stateMachine.Update();
    }
    public void ToggleReadyDrawCanvas(bool isEnabled)
    {
        readyDrawCanvas.SetActive(isEnabled);
    }
    public void ToggleProcessDrawCanvas(bool isEnabled)
    {
        processDrawCanvas.SetActive(isEnabled);
    }
    public void ToggleResultDrawCanvas(bool isEnabled)
    {
        resultDrawCanvas.SetActive(isEnabled);
    }
    public void SingleDrawButton()
    {
        isSingleDraw = true;
        DrawEvent?.Invoke(isSingleDraw);
        stateMachine.ChangeStateTo(stateMachine.processDrawState);        
    }
    public void MultipleDrawButton()
    {
        isSingleDraw = false;
        DrawEvent?.Invoke(isSingleDraw);
        stateMachine.ChangeStateTo(stateMachine.processDrawState);
    }
    public void SkipButton()
    {
        StopAllCoroutines();
        stateMachine.ChangeStateTo(stateMachine.resultDrawState);
    }
    public void CloseButton()
    {
        stateMachine.ChangeStateTo(stateMachine.readyDrawState);
    }
    public GameEntity GetDrawnItemData(int index)
    {
        return drawController.EntityDataList[index];
    }   
}
