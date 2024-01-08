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

    [SerializeField] private UIController uiController;

    private StateMachine stateMachine;

    private DrawController drawController;

    public event Action<bool> DrawEvent;
    public event Action SetObjectToAnimateEvent;

    private bool isSingleDraw;
    public bool IsSingleDraw { get => isSingleDraw; }

    private RectTransform rectToAnimate;
    public RectTransform RectToAnimate { get => rectToAnimate; set { rectToAnimate = value; SetObjectToAnimateEvent?.Invoke(); } }

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
    public void ToggleReadyDrawUI(bool isEnabled)
    {
        uiController.ToggleReadyDrawUI(isEnabled);
    }
    public void ToggleProcessDrawUI(bool isEnabled)
    {
        uiController.ToggleProcessDrawUI(isEnabled);
    }
    public void ToggleResultDrawUI(bool isEnabled)
    {
        uiController.ToggleResultDrawUI(isEnabled);
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
