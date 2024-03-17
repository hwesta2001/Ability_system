using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelControl : MonoBehaviour
{
    [SerializeField] GameObject attackPanel;
    [SerializeField] GameObject defencePanel;
    public void PanelInit()
    {
        attackPanel.SetActive(true);
        defencePanel.SetActive(false);
    }


}
