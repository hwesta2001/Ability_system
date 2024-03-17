using UnityEngine;

[System.Serializable]
public abstract class AbilityBehaviour : MonoBehaviour
{
    public Ability Ability_;
    public abstract void OnAbilityTrigger();
    public abstract void OnUpdate();

}