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


    // void AgilityTrigger methodu AbilitySisteminde buttona týklayýnca çaðrýlýr.
    public void AgilityTrigger(object o, AbilityToStatArgs args)
    {

        // abilityCost globalVerilerdeki StarPoint sayýsýndan az ise    
        if (args.ability_arg.starPointCost <= GlobalVeriler.Instance.StarPoint)
        {

            Debug.Log("<color=orange> AbilityTriggered with this agrs:\n</color>" + args.ability_arg.statsContextType + " :   " + args.ability_arg.modifier.modifierBaseValue);

            OnAgilityTriggered?.Invoke(o, args); // AbilityTrigger gönderilen arg ile Invoke olur.
        }
        // Eger abilitycost globalVerilerdeki StarPoint sayýsýndan daha fazla ise
        else
        {
            Debug.LogWarning("Yetersiz Yýldýz Puaný!!!!!!!!");
            DebugText.ins.AddText("<color=red><b>  Yetersiz Yýldýz Puaný!!!!!!!!  </b></color>");
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
    // Buttonla triger olunca bu Arg'lar eventa gönderilir.
    public Ability ability_arg;

    public AbilityToStatArgs(Ability ability_arg)
    {
        this.ability_arg = ability_arg;
    }
}

public enum PlayerStatContextType { Health, Armor, Damage, Range, AttackSpeed, } //diðer gerekli tipler eklenir.
