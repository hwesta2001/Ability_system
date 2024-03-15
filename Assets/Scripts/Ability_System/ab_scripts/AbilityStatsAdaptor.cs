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

    public float buffTime = 0f; // spelller i�in s�f�rd�r.
    public PlayerStatContextType statsContextType;
    public Modifier modifier;
}

public enum PlayerStatContextType { Health, Armor, Damage, Range, AttackSpeed, } //di�er gerekli tipler eklenir.
