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
    //Animasyonlarý oynatmak için "Clip" in deðiþtirilmesi yeterlidir.
    // Örnek: unitAnimatController.Clip = UnitAnimClip.walking;
    // yukarýldaki þekilde Clip deðiþtiðinde otomaitk walking animasyonuna geçer
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
        //clip deðiþtirildi
        animator.SetFloat("speed", speed);
        animator.SetInteger("clipsEnum", (int)_clip);
    }

    public void OnDecayEnd()
    {
        // decay animation içinde en sonda çaðrýlýr
        // poola göndermek için deactivate object yapýlabilir
        gameObject.SetActive(false);
        Debug.Log("<color=#e69138>" + gameObject.name + " died and decayed.\nReturing to pool</color>");
    }
}
