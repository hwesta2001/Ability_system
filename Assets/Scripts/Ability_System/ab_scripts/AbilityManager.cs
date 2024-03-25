using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityManager : MonoBehaviour
{
    [SerializeField] List<AbilityBehaviour> UnlockedAttacks = new();
    [SerializeField] List<AbilityBehaviour> UnlockedDefences = new();
    [SerializeField] int howManyActiveForStart = 4;

    [Header("<color=red><b><i>MANUALY PUT ALL ABILITY PREFABs IN THIS LIST.</b></i></color>")]
    public List<AbilityBehaviour> AllAbilities = new();


    [SerializeField] AbilityStatsAdaptor adaptor;
    [SerializeField] Transform attackButtonParent, defenceButtonParent;

    List<Button> attackButtons;
    List<Button> defenceButtons;



    void Start()
    {
        ButtonInit();
        SetAllAbilities();
        DisableAllButtons();
        for (int i = 0; i < howManyActiveForStart; i++)
        {
            AddAbilityToCurrent(AllAbilities[i]);
        }
        GetComponent<PanelControl>().PanelInit();
    }

    void DisableAllButtons()
    {
        foreach (var item in attackButtons) item.gameObject.SetActive(false);
        foreach (var item in defenceButtons) item.gameObject.SetActive(false);
    }

    void ButtonInit()
    {
        if (attackButtonParent == null || defenceButtonParent == null)
        {
            Debug.LogWarning("attackButtonParent ya da defence buton parent tensformalrý eksik.");
            Debug.LogWarning("Lütfen inspectorden ekleyin");
            Debug.Break();
        }

        attackButtons = new List<Button>();
        defenceButtons = new List<Button>();

        foreach (Button item in attackButtonParent.GetComponentsInChildren<Button>())
        {
            attackButtons.Add(item);
        }
        foreach (Button item in defenceButtonParent.GetComponentsInChildren<Button>())
        {
            defenceButtons.Add(item);
        }
    }

    void SetAllAbilities()
    {
        int attack_index = 0;
        int defence_index = 0;
        GameObject abilitiesParent = new()
        {
            name = "Abilities_Parent"
        };
        abilitiesParent.transform.parent = transform;
        for (int i = 0; i < AllAbilities.Count; i++)
        {
            AbilityBehaviour ab_behaviour = Instantiate(AllAbilities[i], parent: abilitiesParent.transform);
            AllAbilities.RemoveAt(i);
            AllAbilities.Insert(i, ab_behaviour);
            if (ab_behaviour.Ability_.Type == AbilityType.Attack)
            {
                ab_behaviour.Ability_.abButton = attackButtons[attack_index].GetComponent<ButtonAbility>();
                SetButon(ab_behaviour);
                RefreshButon(ab_behaviour);
                attack_index++;
            }
            else if (ab_behaviour.Ability_.Type == AbilityType.Defence)
            {

                ab_behaviour.Ability_.abButton = defenceButtons[defence_index].GetComponent<ButtonAbility>();
                SetButon(ab_behaviour);
                RefreshButon(ab_behaviour);
                defence_index++;
            }
        }
    }

    public void AddAbilityToCurrent(AbilityBehaviour abilityBehaviour)
    {
        switch (abilityBehaviour.Ability_.Type)
        {
            case AbilityType.Attack:
                if (UnlockedAttacks.Contains(abilityBehaviour)) return;
                UnlockedAttacks.Add(abilityBehaviour);
                break;
            case AbilityType.Defence:
                if (UnlockedDefences.Contains(abilityBehaviour)) return;
                UnlockedDefences.Add(abilityBehaviour);
                break;
        }
        OnCurrentAbilitiesChanged();
    }

    public void RemoveAbilityFromCurrent(AbilityBehaviour abilityBehaviour)
    {
        switch (abilityBehaviour.Ability_.Type)
        {
            case AbilityType.Attack:
                if (!UnlockedAttacks.Contains(abilityBehaviour)) return;
                UnlockedAttacks.Remove(abilityBehaviour);
                break;
            case AbilityType.Defence:
                if (!UnlockedDefences.Contains(abilityBehaviour)) return;
                UnlockedDefences.Remove(abilityBehaviour);
                break;
        }
        OnCurrentAbilitiesChanged();
    }

    void OnCurrentAbilitiesChanged()
    {
        DisableAllButtons();
        if (UnlockedAttacks.Count > 0)
        {
            foreach (var item in UnlockedAttacks)
            {
                SetButon(item);
                item.Ability_.abButton.gameObject.SetActive(true);
            }
        }
        if (UnlockedDefences.Count > 0)
        {
            foreach (var item in UnlockedDefences)
            {
                SetButon(item);
                item.Ability_.abButton.gameObject.SetActive(true);
            }
        }
    }

    void RefreshButon(AbilityBehaviour abilityBehaviour)
    {
        abilityBehaviour.Ability_.abButton.RefreshButton(abilityBehaviour.Ability_);
    }

    void SetButon(AbilityBehaviour abilityBehaviour)
    {
        abilityBehaviour.Ability_.abButton.SetButonListeners(abilityBehaviour, () => OnAdaptorTrigger(abilityBehaviour.Ability_));
    }

    void OnAdaptorTrigger(Ability ab_args)
    {
        adaptor.AgilityTrigger(this, new AbilityToStatArgs(ab_args));
    }
}
