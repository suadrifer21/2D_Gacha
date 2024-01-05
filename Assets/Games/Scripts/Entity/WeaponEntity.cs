using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "ScriptableObjects/WeaponEntity", order = 1)]
public class WeaponEntity : GameEntity
{
    [SerializeField] private int baseAttack;
    [SerializeField] private SpecialEffectType specialType;
    public int BaseAttack { get { return baseAttack; } }
    public SpecialEffectType SpecialType { get { return specialType; } }

    private void OnEnable()
    {
        type = EntityType.Weapon;
    }
}

public enum SpecialEffectType
{
    Vampiric,
    Sharp,
    Piercing,
    Bludgeon,
    Miracle
}