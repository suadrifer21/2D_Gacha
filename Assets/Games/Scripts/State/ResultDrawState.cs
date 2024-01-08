using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultDrawState : IState
{
    private GameController game;

    public static event Action SetResultDataEvent;

    public ResultDrawState(GameController game)
    {
        this.game = game;
    }
    public void Enter()
    {
        Debug.Log("Result Draw");
        game.ToggleResultDrawUI(true);
        SetResultDataEvent?.Invoke();
    }
    public void Exit()
    {
        game.ToggleResultDrawUI(false);
    }
    public void Update()
    {

    }
}
