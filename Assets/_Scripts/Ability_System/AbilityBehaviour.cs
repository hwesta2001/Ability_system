using UnityEngine;

[System.Serializable]
public abstract class AbilityBehaviour : MonoBehaviour
{
    public abstract Ability Ability_ { get; set; }
    public abstract void OnAbilityTrigger();
    public abstract void OnUpdate();
}