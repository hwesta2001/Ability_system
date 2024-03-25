using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ab_Attack : AbilityBehaviour
{
    public override void OnAbilityTrigger()
    {
        DebugText.ins.AddText("<color=orange>Ability_.Name: " + Ability_.Name + "Ability_.Desc: " + Ability_.Description + "</color>");
    }

    public override void OnUpdate() { }
}
