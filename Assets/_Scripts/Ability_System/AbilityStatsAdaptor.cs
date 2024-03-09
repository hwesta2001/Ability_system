using System;
using UnityEngine;

//static singelton da yapýlabilir
//Suan bir gameObjecte konulup gerekli yerlere çekerek kullanýyoruz
public class AbilityStatsAdaptor : MonoBehaviour
{
    // bu eventi dinlemek için OnAgilityTriggered  event'ine üye olunur
    // örnek: abilityStatsAdaptor.OnAgilityTriggered+= SomeListenerMethod;
    public event EventHandler<AbilityToStatArgs> OnAgilityTriggered;

    // void AgilityTrigger methodu AbilitySisteminde buttona týklayýnca çaðrýlýr.
    public void AgilityTrigger(object o, AbilityToStatArgs args)
    {
        OnAgilityTriggered?.Invoke(o, args);
    }

    //public AbilityToStatArgs ToStatARGS = new(); // bu þuan iþlevsiz.
}

[Serializable]
public class AbilityToStatArgs : EventArgs
{
    // bu sýnýfý dýþarýda ayrý bir sýnýf olarak yaptýk çünkü tüm projede bu argumanlar kullanýlabilir.
    // mesela AbilityBehaviour' da bu sýnýf kullanýlmýþtýr kullanýlmýþtýr.
    // [Serializable] olduðu için abilityde bu Arg'lar prefablarda kolayca ayarlanýr
    // Buttonla triger olunca bu Arg'lar eventa gönderilir.
    public float armorValue;
    public float healValue;
    public float attackValue;
    public float attackSpeedValue;
    public float rangeValue;
    public float moveSpeedValue;
    // diðer gerekli paramatreler eklenecektir.
}

public abstract class IModifier
{
    public float armor;

}