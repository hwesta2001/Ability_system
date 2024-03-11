using UnityEngine;

[System.Serializable]
public abstract class AbilityBehaviour : MonoBehaviour
{
    [field: SerializeField] public Ability Ability_ { get; private set; }
    [field: SerializeField] public AbilityToStatArgs AdaptorArg { get; private set; }
    public abstract void OnAbilityTrigger();
    public abstract void OnUpdate();

}