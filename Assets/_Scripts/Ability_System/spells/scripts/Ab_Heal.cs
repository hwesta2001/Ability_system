using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ab_Heal : AbilityBehaviour
{
    [field: SerializeField] public override Ability Ability_ { get; set; }
    [SerializeField] int HealAmount;

    public override void OnAbilityTrigger()
    {
        // HEAL HERE
        Debug.Log($"<color=#274e13> Casted: <b>{Ability_.Name}</b>\n{Ability_.Description}</color>");
    }

    public override void OnUpdate() { }
}
