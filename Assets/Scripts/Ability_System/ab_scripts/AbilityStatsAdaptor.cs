using System;
using System.Collections;
using UnityEngine;

//static singelton da yapýlabilir
//Suan bir gameObjecte konulup gerekli yerlere çekerek kullanýyoruz
public class AbilityStatsAdaptor : MonoBehaviour
{
    // bu eventi dinlemek için OnAgilityTriggered  event'ine üye olunur
    // örnek: abilityStatsAdaptor.OnAgilityTriggered+= SomeListenerMethod;
    public event EventHandler<AbilityToStatArgs> OnAgilityTriggered;
    public void AgilityTrigger(object o, AbilityToStatArgs args)
    {
        // void AgilityTrigger methodu AbilitySisteminde buttona týklayýnca çaðrýlýr.
        OnAgilityTriggered?.Invoke(o, args);
        Debug.Log("<color=orange> AbilityTriggered with this agrs:\n</color>" + args.statsContextType + " :   " + args.modifier.modifierBaseValue);
    }

    void Awake()
    {
        OnAgilityTriggered = null;
    }
}

[Serializable]
public class AbilityToStatArgs : EventArgs
{
    // Buttonla triger olunca bu Arg'lar eventa gönderilir.

    public float buffTime = 0f; // 0 kalýcý olarak ekler
    public PlayerStatContextType statsContextType;
    public Modifier modifier;
}

public enum PlayerStatContextType { Health, Armor, Damage, Range, AttackSpeed, } //diðer gerekli tipler eklenir.
