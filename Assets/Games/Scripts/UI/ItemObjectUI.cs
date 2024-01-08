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
    [SerializeField] private Image backgroundImage;

    public void SetData(GameEntity itemData, BackgroundSpritesHolder spritesHolder)
    {
        itemImage.sprite = itemData.ImageSprite;
        nameText.text = itemData.Name;
        rarityText.text = itemData.Rank.ToString();

        switch (itemData.Rank)
        {
            case RarityRank.Common:
                backgroundImage.sprite = spritesHolder.CommonSprite;
                break;
            case RarityRank.Uncommon:
                backgroundImage.sprite = spritesHolder.UncommonSprite;
                break;
            case RarityRank.Rare:
                backgroundImage.sprite = spritesHolder.RareSprite;
                break;
            case RarityRank.SuperRare:
                backgroundImage.sprite = spritesHolder.SuperRareSprite;
                break;
        }
    }
}
