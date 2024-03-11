using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ab_Heal : AbilityBehaviour
{
    public override void OnAbilityTrigger()
    {
        // HEAL HERE
        DebugText.ins.AddText("<color=green>Ability_.Name: " + Ability_.Name + "\nAbility_.Desc: " + Ability_.Description + "</color>");
    }

    public override void OnUpdate()
    {

    }
}
