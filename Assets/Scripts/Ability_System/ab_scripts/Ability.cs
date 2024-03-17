using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct Ability //struc cünkü sadece data container olarak kullanýlacak
{
    public string Name;
    public AbilityType Type;
    public int cost;
    public int currentTotal;
    [TextArea(0, 1)] public string Description;
    public ButtonAbility abButton;
    [field: SerializeField] public AbilityToStatArgs AdaptorArg { get; private set; }
}


public enum AbilityType
{
    Attack = 0,
    Defence = 1,
}