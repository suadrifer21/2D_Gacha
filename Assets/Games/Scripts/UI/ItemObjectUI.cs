using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemObjectUI : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI rarityText;

    public void SetData(GameEntity itemData)
    {
        itemImage.sprite = itemData.ImageSprite;
        nameText.text = itemData.Name;
        rarityText.text = itemData.Rank.ToString();
    }
}
