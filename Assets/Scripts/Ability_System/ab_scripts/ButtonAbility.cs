using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAbility : MonoBehaviour
{
    Button button;
    [SerializeField] TextMeshProUGUI ab_name;
    [SerializeField] TextMeshProUGUI ab_total_text;
    [SerializeField] TextMeshProUGUI cost_text;

    void Awake()
    {
        button = GetComponent<Button>();
    }

    public void RefreshButton(Ability ability)
    {
        gameObject.name = ability.Name;
        ab_name.text = ability.Name;
        ab_total_text.text = ability.currentTotal.ToString();
        cost_text.text = ability.cost.ToString();
    }

    public void SetButonListeners(AbilityBehaviour abilityBehaviour, Action func)
    {
        abilityBehaviour.Ability_.abButton.button.onClick.RemoveAllListeners();
        abilityBehaviour.Ability_.abButton.button.onClick.AddListener(abilityBehaviour.OnAbilityTrigger);
        abilityBehaviour.Ability_.abButton.button.onClick.AddListener(() => func?.Invoke());
    }
}
