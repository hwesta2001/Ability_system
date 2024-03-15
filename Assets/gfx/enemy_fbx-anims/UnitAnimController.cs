using UnityEngine;

public enum UnitAnimClip { walking = 0, attack = 1, idle = 2, death = 3 }

[RequireComponent(typeof(Animator))]
public class UnitAnimController : MonoBehaviour
{

    [SerializeField, Range(1f, 5f)] float speed;
    UnitAnimClip clip;
    Animator animator;

    void OnValidate()
    {
        if (animator == null) animator = GetComponent<Animator>();
        animator.SetFloat("speed", speed);
    }
    private void OnEnable()
    {

        animator.SetFloat("speed", speed);
        Clip = UnitAnimClip.walking;
    }
    //Animasyonlar� oynatmak i�in "Clip" in de�i�tirilmesi yeterlidir.
    // �rnek: unitAnimatController.Clip = UnitAnimClip.walking;
    // yukar�ldaki �ekilde Clip de�i�ti�inde otomaitk walking animasyonuna ge�er
    public UnitAnimClip Clip
    {
        get
        {
            return clip;
        }
        set
        {
            clip = value;
            OnAnimClipChanged(value);
        }
    }


    void OnAnimClipChanged(UnitAnimClip _clip)
    {
        //clip de�i�tirildi
        animator.SetFloat("speed", speed);
        animator.SetInteger("clipsEnum", (int)_clip);
    }

    public void OnDecayEnd()
    {
        // decay animation i�inde en sonda �a�r�l�r
        // poola g�ndermek i�in deactivate object yap�labilir
        gameObject.SetActive(false);
        Debug.Log("<color=#e69138>" + gameObject.name + " died and decayed.\nReturing to pool</color>");
    }
}
