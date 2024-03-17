using System;
using System.Collections;
using UnityEngine;

//static singelton da yap�labilir
//Suan bir gameObjecte konulup gerekli yerlere �ekerek kullan�yoruz
public class AbilityStatsAdaptor : MonoBehaviour
{
    // bu eventi dinlemek i�in OnAgilityTriggered  event'ine �ye olunur
    // �rnek: abilityStatsAdaptor.OnAgilityTriggered+= SomeListenerMethod;
    public event EventHandler<AbilityToStatArgs> OnAgilityTriggered;
    public void AgilityTrigger(object o, AbilityToStatArgs args)
    {
        // void AgilityTrigger methodu AbilitySisteminde buttona t�klay�nca �a�r�l�r.
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
    // Buttonla triger olunca bu Arg'lar eventa g�nderilir.

    public float buffTime = 0f; // 0 kal�c� olarak ekler
    public PlayerStatContextType statsContextType;
    public Modifier modifier;
}

public enum PlayerStatContextType { Health, Armor, Damage, Range, AttackSpeed, } //di�er gerekli tipler eklenir.
