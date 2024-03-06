using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityManager : MonoBehaviour
{
    [SerializeField] List<Button> allButtons = new(); //tüm buttonlarý elle ekleyin
    [SerializeField] List<AbilityBehaviour> CurrentAbilities = new();

    void Start()
    {
        OnCurrentAbilitiesChanged(); // debug için
    }

    public void AddAbilityToCurrent(AbilityBehaviour abilityBehaviour)
    {
        CurrentAbilities.Add(abilityBehaviour);
        OnCurrentAbilitiesChanged();
    }

    public void RemoveAbilityFromCurrent(AbilityBehaviour abilityBehaviour)
    {
        if (!CurrentAbilities.Contains(abilityBehaviour)) return;
        CurrentAbilities.Remove(abilityBehaviour);
        OnCurrentAbilitiesChanged();
    }

    void OnCurrentAbilitiesChanged()
    {
        // CurrentAbilities listesi deðiþtiðinde çaðrýlýr.
        SetListButtons();
    }

    void SetListButtons()
    {
        foreach (var button in allButtons) button.gameObject.SetActive(false);  // once tüm butonlarý kapat.
        if (CurrentAbilities.Count <= 0) return; // hiç ability yok ise elimizde return; 

        // elimizde ability var
        for (int i = 0; i < CurrentAbilities.Count; i++)
        {
            SetButon(CurrentAbilities[i], i);
        }
    }

    void SetButon(AbilityBehaviour abilityBehaviour, int buttonIndex)
    {
        allButtons[buttonIndex].image.sprite = abilityBehaviour.Ability_.Icon;
        allButtons[buttonIndex].onClick.RemoveAllListeners();
        allButtons[buttonIndex].onClick.AddListener(abilityBehaviour.OnAbilityTrigger);
        allButtons[buttonIndex].onClick.AddListener(() => RemoveAbilityFromCurrent(abilityBehaviour));
        allButtons[buttonIndex].gameObject.SetActive(true);
    }

}
