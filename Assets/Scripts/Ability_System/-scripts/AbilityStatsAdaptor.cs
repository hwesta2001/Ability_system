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
    CharacterStats characterStats;
    public void AgilityTrigger(object o, AbilityToStatArgs args)
    {
        // void AgilityTrigger methodu AbilitySisteminde buttona týklayýnca çaðrýlýr.
        OnAgilityTriggered?.Invoke(o, args);
    }
    WaitForSeconds waitForSecond;
    void Start()
    {
        characterStats = CharacterStats.Instance;
        OnAgilityTriggered = null;
        OnAgilityTriggered += DetermineModifier;
    }

    void DetermineModifier(object o, AbilityToStatArgs args)
    {
        switch (args.statsContextType)
        {
            case PlayerStatContextType.Health:
                characterStats._healthPoint.AddModifier(args.modifier);
                break;
            case PlayerStatContextType.Armor:
                characterStats._physicalArmor.AddModifier(args.modifier);
                break;
            case PlayerStatContextType.Damage:

                break;
            case PlayerStatContextType.AttackSpeed:

                break;
            default:
                break;
        }
        // characterStats.STATS_HESAPLA BURDA
        characterStats.StatsMassCalculation();

        if (args.buffTime > 0)
        {
            // task asyn ile deðiþebilr.
            waitForSecond = new WaitForSeconds(args.buffTime);
            StartCoroutine(RemoveBuffAfterTime(args));
        }

    }

    IEnumerator RemoveBuffAfterTime(AbilityToStatArgs args)
    {
        // remove buff form list
        yield return waitForSecond;
        switch (args.statsContextType)
        {
            case PlayerStatContextType.Health:
                characterStats._healthPoint.RemoveModifier(args.modifier);
                break;
            case PlayerStatContextType.Armor:
                characterStats._physicalArmor.RemoveModifier(args.modifier);
                break;
            case PlayerStatContextType.Damage:

                break;
            case PlayerStatContextType.AttackSpeed:

                break;
            default:
                break;
        }

        // characterStats.STATS_HESAPLA BURDA
        characterStats.StatsMassCalculation();
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

public enum PlayerStatContextType { Health, Armor, Damage, AttackSpeed, } //diðer gerekli tipler eklenir.
