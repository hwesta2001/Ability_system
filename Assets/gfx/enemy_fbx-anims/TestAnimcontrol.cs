using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnimcontrol : MonoBehaviour
{
    [SerializeField] UnitAnimClip current_clip;
    UnitAnimClip clip;
    UnitAnimController uaControl;
    void Awake()
    {
        uaControl = GetComponent<UnitAnimController>();
    }

    private void OnEnable()
    {
        clip = current_clip = UnitAnimClip.walking;
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            current_clip = UnitAnimClip.attack;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            current_clip = UnitAnimClip.idle;

        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            current_clip = UnitAnimClip.death;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            current_clip = UnitAnimClip.walking;
        }


        if (current_clip != clip)
        {
            clip = current_clip;
            uaControl.Clip = clip;
        }
    }
}
