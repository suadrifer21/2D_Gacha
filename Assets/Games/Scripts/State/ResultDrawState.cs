using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultDrawState : IState
{
    private GameController game;

    public ResultDrawState(GameController game)
    {
        this.game = game;
    }
    public void Enter()
    {
        Debug.Log("Result Draw");
        game.ToggleResultDrawCanvas(true);
        for(int i = 0; i < game.drawResultUIParent.childCount; i++)
        {             
            if (game.IsSingleDraw) 
            {
                if(i==0)                 
                    game.drawResultUIParent.GetChild(i).GetComponent<ItemObjectUI>().SetData(game.GetDrawnItemData(i));
                else
                    game.drawResultUIParent.GetChild(i).gameObject.SetActive(false);
            }    
            else
            {
                game.drawResultUIParent.GetChild(i).GetComponent<ItemObjectUI>().SetData(game.GetDrawnItemData(i));
                game.drawResultUIParent.GetChild(i).gameObject.SetActive(true);
            }
        }
    }
    public void Exit()
    {
        game.ToggleResultDrawCanvas(false);
    }
    public void Update()
    {

    }
}
