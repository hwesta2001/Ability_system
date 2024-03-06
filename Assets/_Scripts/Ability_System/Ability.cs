using UnityEngine;

[System.Serializable]
public struct Ability //struc cünkü sadece data container olarak kullanýlacak
{
    public Sprite Icon;
    public string Name;
    public AbilityType Type;
    [TextArea(0, 1)] public string Description;
}

public enum AbilityType
{
    nonType = 0, // nonType, dummy abilitlerde kullanmak için dursun.
    Upgrade = 1, // Sadece PLAYER'A ÖZEL, KALICI, adý üstünde "Upgrade"ler. 
    Spell,       // aktif speller. player ya da enemy ye direk etki eder.
    Buff,        // player ve enemy lere ekti eden, pasif, OLUMLU, zamanlý abilityler
    Curse,       // player ve enemy lere ekti eden, pasif, OLUMSUZ, zamanlý abilityler
}