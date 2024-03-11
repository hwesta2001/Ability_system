using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class AbilityPool : MonoBehaviour
{
    [Header("<color=red>Þimdilik tüm Ability'leri listelerine elle yerleþtirmek gereklidir\nÝleride gerekirse otomatik çekilip ayarlanabilir.\n</color>")]

    public List<AbilityBehaviour> Upgrades;
    public List<AbilityBehaviour> Spells;
    public List<AbilityBehaviour> Buffs;
    public List<AbilityBehaviour> Curses;
}
