using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ab_Attack : AbilityBehaviour
{
    public override void OnAbilityTrigger()
    {
        DebugText.ins.AddText("<color=red>Ability_.Name: " + Ability_.Name + "\nAbility_.Desc: " + Ability_.Description + "</color>");
    }

    public override void OnUpdate() { }
}