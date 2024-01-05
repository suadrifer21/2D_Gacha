using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawController : MonoBehaviour
{
    [SerializeField] private DrawTable drawTableData;

    private List<GameEntity> entityDataList = new List<GameEntity>();

    public List<GameEntity> EntityDataList { get => entityDataList; }
    private void Start()
    {
        GameController.instance.DrawEvent += DoDraw;
    }
    private void DoDraw(bool isSingle)
    {
        entityDataList.Clear();
        if (isSingle)
            SingleDraw();
        else
            MultipleDraw();
    }
    private void SingleDraw()
    {
        entityDataList.Add(drawTableData.GetItem());
    }
    private void MultipleDraw()
    {
        for(int i = 0; i < 10; i++)
        {
            SingleDraw();
        }
    } 
    private void OnDisable()
    {
        GameController.instance.DrawEvent -= DoDraw;
    }
}
