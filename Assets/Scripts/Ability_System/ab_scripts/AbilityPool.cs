using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class AbilityPool : MonoBehaviour
{

    public AbilityContainer AllAbilitiesContainer;

    public List<AbilityBehaviour> nontypeAbilities = new();
    public List<AbilityBehaviour> Upgrades = new();
    public List<AbilityBehaviour> Spells = new();
    public List<AbilityBehaviour> Buffs = new();
    public List<AbilityBehaviour> Curses = new();
    public int totalAbilityCount;
    private void Start()
    {
        SetAllAbilites();
    }

    [ContextMenu("SetAllAbilites")]
    void SetAllAbilites()
    {
        nontypeAbilities.Clear();
        Upgrades.Clear();
        Spells.Clear();
        Buffs.Clear();
        Curses.Clear();
        foreach (var item in AllAbilitiesContainer.abilities)
        {
            SeperateAbilitiesByAbilityType(item);
            totalAbilityCount++;
        }
    }

    void SeperateAbilitiesByAbilityType(AbilityBehaviour ab)
    {
        switch (ab.Ability_.Type)
        {
            case AbilityType.nonType:
                nontypeAbilities.Add(ab);
                break;
            case AbilityType.Upgrade:
                Upgrades.Add(ab);
                break;
            case AbilityType.Spell:
                Spells.Add(ab);
                break;
            case AbilityType.Buff:
                Buffs.Add(ab);
                break;
            case AbilityType.Curse:
                Curses.Add(ab);
                break;
            default:
                nontypeAbilities.Add(ab);
                break;
        }
    }

}
