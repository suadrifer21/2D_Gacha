using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "ScriptableObjects/CharacterEntity", order = 1)]
public class CharacterEntity : GameEntity 
{ 
    [SerializeField] private int hitPoints;
    [SerializeField] private int attack;
    [SerializeField] private int defense;
    public int HP { get { return hitPoints; } }
    public int Attack { get { return attack; } }
    public int Defense { get { return defense; } }

    private void OnEnable()
    {
        type = EntityType.Character;
    }
}