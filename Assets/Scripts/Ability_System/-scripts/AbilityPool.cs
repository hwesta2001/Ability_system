using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class AbilityPool : MonoBehaviour
{
    [Header("<color=red>�imdilik t�m Ability'leri listelerine elle yerle�tirmek gereklidir\n�leride gerekirse otomatik �ekilip ayarlanabilir.\n</color>")]

    public List<AbilityBehaviour> Upgrades;
    public List<AbilityBehaviour> Spells;
    public List<AbilityBehaviour> Buffs;
    public List<AbilityBehaviour> Curses;
}
