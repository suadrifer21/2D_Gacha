using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessDrawState : IState
{
    private GameController game;

    public ProcessDrawState(GameController game)
    {
        this.game = game;
    }
    public void Enter()
    {
        Debug.Log("Process Draw");
        game.ToggleProcessDrawCanvas(true);

        game.StartCoroutine(ShowDraw(game.IsSingleDraw));
    }
    public void Exit()
    {
        game.ToggleProcessDrawCanvas(false);
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
            game.itemObjectUI.SetData(game.GetDrawnItemData(currentDraw));
            yield return new WaitForSeconds(2f);
            currentDraw++;
        }
    }
}