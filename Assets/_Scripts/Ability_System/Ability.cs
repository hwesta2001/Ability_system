using UnityEngine;

[System.Serializable]
public struct Ability //struc c�nk� sadece data container olarak kullan�lacak
{
    public Sprite Icon;
    public string Name;
    public AbilityType Type;
    [TextArea(0, 1)] public string Description;
}

public enum AbilityType
{
    nonType = 0, // nonType, dummy abilitlerde kullanmak i�in dursun.
    Upgrade = 1, // Sadece PLAYER'A �ZEL, KALICI, ad� �st�nde "Upgrade"ler. 
    Spell,       // aktif speller. player ya da enemy ye direk etki eder.
    Buff,        // player ve enemy lere ekti eden, pasif, OLUMLU, zamanl� abilityler
    Curse,       // player ve enemy lere ekti eden, pasif, OLUMSUZ, zamanl� abilityler
}