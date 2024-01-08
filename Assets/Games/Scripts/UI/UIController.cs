using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour 
{
    [SerializeField] private GameObject readyDrawUI;
    [SerializeField] private GameObject processDrawUI;
    [SerializeField] private GameObject resultDrawUI;
      
    [SerializeField] private Transform drawResultUIParent;
    [SerializeField] private ItemDetailUI itemDetailUI;

    [SerializeField] private BackgroundSpritesHolder spritesHolder; 

    private GameController game;
    private UIObjectPool uiObjectPool;
    private ItemObjectUI processItemObjectUI;

    public BackgroundSpritesHolder SpritesHolder { get => spritesHolder; }

    void Start()
    {
        game = GameController.instance;
        uiObjectPool = GetComponent<UIObjectPool>();

        ProcessDrawState.DrawDataEvent += SetProcessUI;
        ResultDrawState.SetResultDataEvent += SetResultUI;

        for (int i = 0; i < drawResultUIParent.childCount; i++)
        {
            int buttonIndex = i;
            drawResultUIParent.GetChild(i).GetComponent<Button>().onClick.AddListener(() => itemDetailUI.ShowItemDetailUI(buttonIndex));
        }

    }
    public void ToggleReadyDrawUI(bool isEnabled)
    {
        readyDrawUI.SetActive(isEnabled);
    }
    public void ToggleProcessDrawUI(bool isEnabled)
    {
        processDrawUI.SetActive(isEnabled);

        if (!isEnabled)
        {
            processDrawUI.gameObject.SetActive(false);
        }
    }
    public void ToggleResultDrawUI(bool isEnabled)
    {
        resultDrawUI.SetActive(isEnabled);
    }
    private void SetProcessUI(GameEntity gameEntity)
    {
        if(processItemObjectUI == null)
        {
            processItemObjectUI = uiObjectPool.GetPooledProcessItemUI();
        }
        else
        {
            ItemObjectUI temp = processItemObjectUI;
            processItemObjectUI = uiObjectPool.GetPooledProcessItemUI();

            temp.GetComponent<RectTransform>().localScale = uiObjectPool.DefaultObjectScale;
            temp.gameObject.SetActive(false);
        }
        game.RectToAnimate = processItemObjectUI.GetComponent<RectTransform>();
        processItemObjectUI.SetData(gameEntity, spritesHolder);
        processItemObjectUI.gameObject.SetActive(true);
    }
    private void SetResultUI()
    {
        for (int i = 0; i < drawResultUIParent.childCount; i++)
        {
            if (game.IsSingleDraw)
            {
                if (i == 0)
                    drawResultUIParent.GetChild(i).GetComponent<ItemObjectUI>().SetData(game.GetDrawnItemData(i), spritesHolder);
                else
                    drawResultUIParent.GetChild(i).gameObject.SetActive(false);
            }
            else
            {
                drawResultUIParent.GetChild(i).GetComponent<ItemObjectUI>().SetData(game.GetDrawnItemData(i), spritesHolder);
                drawResultUIParent.GetChild(i).gameObject.SetActive(true);
            }
        }
    }

    private void OnDisable()
    {
        ProcessDrawState.DrawDataEvent -= SetProcessUI;
        ResultDrawState.SetResultDataEvent -= SetResultUI;
    }
}

[Serializable]
public class BackgroundSpritesHolder
{
    [SerializeField] private Sprite commonSprite;
    [SerializeField] private Sprite uncommonSprite;
    [SerializeField] private Sprite rareSprite;
    [SerializeField] private Sprite superRareSprite;

    public Sprite CommonSprite { get => commonSprite; }
    public Sprite UncommonSprite { get => uncommonSprite; }
    public Sprite RareSprite { get => rareSprite; }
    public Sprite SuperRareSprite { get => superRareSprite; }
}