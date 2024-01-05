using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameEntity : ScriptableObject
{
    [SerializeField] protected int id;
    [SerializeField] protected string entityName;
    [SerializeField] protected EntityType type;
    [SerializeField] protected RarityRank rank;
    [SerializeField] protected Sprite imageSprite;
    public int Id { get { return id; } }
    public string Name { get { return entityName; } }
    public EntityType Type { get { return type; } }
    public RarityRank Rank { get { return rank; } }
    public Sprite ImageSprite { get { return imageSprite; } }

}

public enum EntityType
{
    Character,
    Weapon
}
public enum RarityRank
{
    Common,
    Uncommon,
    Rare,
    SuperRare
}