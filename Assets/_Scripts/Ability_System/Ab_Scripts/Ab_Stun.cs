using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ab_Stun : AbilityBehaviour
{
    public override void OnAbilityTrigger()
    {
        // stun here
        DebugText.ins.AddText("<color=#00ffffff>Ability_.Name: " + Ability_.Name + "\nAbility_.Desc: " + Ability_.Description + "</color>");
    }

    public override void OnUpdate()
    {

    }
}
