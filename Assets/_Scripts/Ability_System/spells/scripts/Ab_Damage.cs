using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ab_Damage : AbilityBehaviour
{
    [field: SerializeField]
    public override Ability Ability_ { get; set; }
    public override void OnAbilityTrigger()
    {
        Debug.Log($"<color=red>{Ability_.Name} damageded.\n {Ability_.Description}</color>");
    }

    public override void OnUpdate() { }
}
