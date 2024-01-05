using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyDrawState : IState
{
    private GameController game;

    public ReadyDrawState(GameController game)
    {
        this.game = game;
    }
    public void Enter()
    {
        Debug.Log("Ready Draw");
        game.ToggleReadyDrawCanvas(true);
    }
    public void Exit()
    {
        game.ToggleReadyDrawCanvas(false);
    }
    public void Update()
    {
        
    }
}
