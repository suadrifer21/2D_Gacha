using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemDetailUI : ItemObjectUI 
{
    [SerializeField] private TextMeshProUGUI typeText;

    [SerializeField] private GameObject charDetailHolder;
    [SerializeField] private TextMeshProUGUI charHPText;
    [SerializeField] private TextMeshProUGUI charAttackText;
    [SerializeField] private TextMeshProUGUI charDefenseText;

    [SerializeField] private GameObject weaponDetailHolder;
    [SerializeField] private TextMeshProUGUI weaponBaseAttackText;
    [SerializeField] private TextMeshProUGUI weaponSpecialEffectText;

    [SerializeField] private GameObject itemDetailParent;
    [SerializeField] private UIController uIController;

    public void ToggleItemDetail(bool isShow)
    {
        itemDetailParent.SetActive(isShow);
    }
    public void ShowItemDetailUI(int index)
    {
        GameEntity gameEntity = GameController.instance.GetDrawnItemData(index);
        base.SetData(gameEntity, uIController.SpritesHolder);

        if(gameEntity is CharacterEntity characterEntity)
        {
            charDetailHolder.SetActive(true);
            weaponDetailHolder.SetActive(false);
            typeText.text = characterEntity.Type.ToString();
            charHPText.text = characterEntity.HP.ToString();
            charAttackText.text = characterEntity.Attack.ToString();
            charDefenseText.text = characterEntity.Defense.ToString();
        }else if (gameEntity is WeaponEntity weaponEntity)
        {
            charDetailHolder.SetActive(false);
            weaponDetailHolder.SetActive(true);
            typeText.text = weaponEntity.Type.ToString();
            weaponBaseAttackText.text = weaponEntity.BaseAttack.ToString();
            weaponSpecialEffectText.text = weaponEntity.SpecialType.ToString();
        }

        ToggleItemDetail(true);
    }
}
