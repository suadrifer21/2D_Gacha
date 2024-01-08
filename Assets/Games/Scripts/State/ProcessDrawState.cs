using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ProcessDrawState : IState
{
    private GameController game;

    public static event Action<GameEntity> DrawDataEvent;



    RectTransform targetRect;
    //public Vector2 startPosition = new Vector2(2,2);
    //public Vector2 endPosition = Vector2.one;
    public float duration = 3f;

    public ProcessDrawState(GameController game)
    {
        this.game = game;

        game.SetObjectToAnimateEvent += DoDrawAnimation;
    }
    public void Enter()
    {
        Debug.Log("Process Draw");
        game.ToggleProcessDrawUI(true);

        game.StartCoroutine(ShowDraw(game.IsSingleDraw));
    }
    public void Exit()
    {
        game.ToggleProcessDrawUI(false);
    }
    public void Update()
    {

    }
    
    IEnumerator ShowDraw(bool isSingleDraw)
    {
        int drawAmount = 0;
        int currentDraw = 0;
        if (isSingleDraw)
            drawAmount = 1;
        else
            drawAmount = 10;
        while (currentDraw < drawAmount)
        {
            DrawDataEvent?.Invoke(game.GetDrawnItemData(currentDraw));
            canContinue = false;
            yield return new WaitUntil(CanContinueProcess);
            currentDraw++;
        }
    }
    
    void DoDrawAnimation()
    {
        targetRect = game.RectToAnimate;
        // Use DOTween to animate the anchoredPosition of the RectTransform
        //targetRect.DOAnchorPos(endPosition, duration).SetEase(Ease.OutBack)
        Debug.Log("s");
        targetRect.DOScale(Vector3.one,duration).SetEase(Ease.OutBack)
            .OnComplete(OnSummonComplete); // You can add a callback for completion if needed
    }

    bool canContinue;
    void OnSummonComplete()
    {
        canContinue = true;
    }
    bool CanContinueProcess()
    {
        return canContinue;
    }

    ~ProcessDrawState()
    {
        game.SetObjectToAnimateEvent -= DoDrawAnimation;
    }
}