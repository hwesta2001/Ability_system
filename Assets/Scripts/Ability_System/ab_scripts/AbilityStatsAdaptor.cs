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

    public float buffTime = 0f; // spelller için sýfýrdýr.
    public PlayerStatContextType statsContextType;
    public Modifier modifier;
}

public enum PlayerStatContextType { Health, Armor, Damage, Range, AttackSpeed, } //diðer gerekli tipler eklenir.
