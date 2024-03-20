using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityToCharStats : MonoBehaviour
{
    [SerializeField] AbilityStatsAdaptor adaptor;
    [SerializeField] CharacterStats characterStats;
   
    WaitForSeconds waitForSecond;

    void Start()
    {
        if (characterStats == null) characterStats = CharacterStats.Instance;
        if (adaptor == null) adaptor = FindFirstObjectByType<AbilityStatsAdaptor>();
        adaptor.OnAgilityTriggered += DetermineAndAddModifier;
    }

    void DetermineAndAddModifier(object o, AbilityToStatArgs args)
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
            // custom yield consturucture araþtýr.
            // while ile oluþtur.
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