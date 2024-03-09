using System;
using UnityEngine;

//static singelton da yap�labilir
//Suan bir gameObjecte konulup gerekli yerlere �ekerek kullan�yoruz
public class AbilityStatsAdaptor : MonoBehaviour
{
    // bu eventi dinlemek i�in OnAgilityTriggered  event'ine �ye olunur
    // �rnek: abilityStatsAdaptor.OnAgilityTriggered+= SomeListenerMethod;
    public event EventHandler<AbilityToStatArgs> OnAgilityTriggered;

    // void AgilityTrigger methodu AbilitySisteminde buttona t�klay�nca �a�r�l�r.
    public void AgilityTrigger(object o, AbilityToStatArgs args)
    {
        OnAgilityTriggered?.Invoke(o, args);
    }

    //public AbilityToStatArgs ToStatARGS = new(); // bu �uan i�levsiz.
}

[Serializable]
public class AbilityToStatArgs : EventArgs
{
    // bu s�n�f� d��ar�da ayr� bir s�n�f olarak yapt�k ��nk� t�m projede bu argumanlar kullan�labilir.
    // mesela AbilityBehaviour' da bu s�n�f kullan�lm��t�r kullan�lm��t�r.
    // [Serializable] oldu�u i�in abilityde bu Arg'lar prefablarda kolayca ayarlan�r
    // Buttonla triger olunca bu Arg'lar eventa g�nderilir.
    public float armorValue;
    public float healValue;
    public float attackValue;
    public float attackSpeedValue;
    public float rangeValue;
    public float moveSpeedValue;
    // di�er gerekli paramatreler eklenecektir.
}

public abstract class IModifier
{
    public float armor;

}