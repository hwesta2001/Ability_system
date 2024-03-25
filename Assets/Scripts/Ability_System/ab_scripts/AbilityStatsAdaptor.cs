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


    // void AgilityTrigger methodu AbilitySisteminde buttona t�klay�nca �a�r�l�r.
    public void AgilityTrigger(object o, AbilityToStatArgs args)
    {

        // abilityCost globalVerilerdeki StarPoint say�s�ndan az ise    
        if (args.ability_arg.starPointCost <= GlobalVeriler.Instance.StarPoint)
        {

            Debug.Log("<color=orange> AbilityTriggered with this agrs:\n</color>" + args.ability_arg.statsContextType + " :   " + args.ability_arg.modifier.modifierBaseValue);

            OnAgilityTriggered?.Invoke(o, args); // AbilityTrigger g�nderilen arg ile Invoke olur.
        }
        // Eger abilitycost globalVerilerdeki StarPoint say�s�ndan daha fazla ise
        else
        {
            Debug.LogWarning("Yetersiz Y�ld�z Puan�!!!!!!!!");
            DebugText.ins.AddText("<color=red><b>  Yetersiz Y�ld�z Puan�!!!!!!!!  </b></color>");
        }
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
    public Ability ability_arg;

    public AbilityToStatArgs(Ability ability_arg)
    {
        this.ability_arg = ability_arg;
    }
}

public enum PlayerStatContextType { Health, Armor, Damage, Range, AttackSpeed, } //di�er gerekli tipler eklenir.
