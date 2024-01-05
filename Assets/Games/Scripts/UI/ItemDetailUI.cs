using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemDetailUI : MonoBehaviour
{
    [SerializeField] private GameObject itemDetailParent;

    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI rarityText;
    [SerializeField] private TextMeshProUGUI typeText;

    private void Start()
    {
        Transform drawResultUIParent = GameController.instance.drawResultUIParent;
        print("s");

        for (int i = 0; i < drawResultUIParent.childCount; i++)
        {
            int buttonIndex = i;
            drawResultUIParent.GetChild(i).GetComponent<Button>().onClick.AddListener(() => ShowItemDetailUI(buttonIndex));
        }
    }
    public void SetData(GameEntity itemData)
    {
        itemImage.sprite = itemData.ImageSprite;
        nameText.text = itemData.Name;
        rarityText.text = itemData.Rank.ToString();
        typeText.text = itemData.Type.ToString();
    }
    public void ToggleItemDetail(bool isShow)
    {
        itemDetailParent.SetActive(isShow);
    }
    public void ShowItemDetailUI(int index)
    {
        SetData(GameController.instance.GetDrawnItemData(index));
        ToggleItemDetail(true);
    }
}
