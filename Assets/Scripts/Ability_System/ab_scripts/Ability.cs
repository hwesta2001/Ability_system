using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Ability
{
    public string Name;
    public AbilityType Type;
    [TextArea(0, 1)] public string Description;
    public ButtonAbility abButton;
    [Header("Args")]
    public PlayerStatContextType statsContextType;
    public Modifier modifier;
    public int starPointCost;
    public float currentTotalStatCount;
    public float buffTime; // 0 kalýcý olarak ekler

}


public enum AbilityType
{
    Attack = 0,
    Defence = 1,
}