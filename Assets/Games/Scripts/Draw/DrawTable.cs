using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DrawTableData", menuName = "ScriptableObjects/DrawTable", order = 1)]
public class DrawTable : ScriptableObject
{
    public List<RarityWeight> characterRarityWeightList;
    public List<RarityWeight> weaponRarityWeightList;
    public List<GameEntity> itemList;
    [NonSerialized]
    private int totalWeight = -1;
    public int TotalWeight
    {
        get {
            if (totalWeight == -1)
            {
                CalculateTotalWeight();
            }
            return totalWeight;
        }
    }
    private void CalculateTotalWeight()
    {
        totalWeight = 0;
        for(int i = 0; i <itemList.Count; i++)
        {
            totalWeight += GetItemWeight(itemList[i]);
        }
    }
    public GameEntity GetItem() 
    {
        int roll = UnityEngine.Random.Range(0, TotalWeight);
        for(int i = 0; i < itemList.Count; i++)
        {
            roll -= GetItemWeight(itemList[i]);

            if (roll < 0)
            {
                return itemList[i];
            }
        }

        return itemList[0];
    }

    private int GetItemWeight(GameEntity gameEntity)
    {
        int weight = 0;

        List<RarityWeight> weightList = new List<RarityWeight>();
        if (gameEntity is CharacterEntity)
            weightList = characterRarityWeightList;
        else if (gameEntity is WeaponEntity)
            weightList = weaponRarityWeightList;

        foreach(RarityWeight r in weightList)
        {
            if(gameEntity.Rank == r.rank)
            {
                weight = r.weight;
                break;
            }
        }
        return weight;
    }
}

[Serializable]
public class RarityWeight
{
    public RarityRank rank;
    public int weight;
}
/*
[Serializable]
public class DrawItem
{
    public GameEntity item;
    public int weight;

}
*/