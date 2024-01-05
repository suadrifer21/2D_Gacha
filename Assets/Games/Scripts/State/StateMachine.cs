using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    public IState CurrentState { get; private set; }

    public ReadyDrawState readyDrawState;
    public ProcessDrawState processDrawState;
    public ResultDrawState resultDrawState;

    public event Action<IState> stateChanged;
    
    public StateMachine(GameController game)
    {
        this.readyDrawState = new ReadyDrawState(game);
        this.processDrawState = new ProcessDrawState(game);
        this.resultDrawState = new ResultDrawState(game);
    }
    public void Initialize(IState state)
    {
        CurrentState = state;
        CurrentState.Enter();
        stateChanged?.Invoke(state);
    }
    public void Update()
    {
        if (CurrentState != null)
        {
            CurrentState.Update();
        }
    }
    public void ChangeStateTo(IState nextState)
    {
        CurrentState.Exit();
        CurrentState = nextState;
        CurrentState.Enter();
        stateChanged?.Invoke(nextState);
    }
}
