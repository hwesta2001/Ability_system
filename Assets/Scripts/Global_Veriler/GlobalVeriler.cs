using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GlobalVeriler : MonoBehaviour
{
    public static GlobalVeriler Instance;
    [SerializeField] AbilityStatsAdaptor abilityStatsAdaptor;
    void Awake()
    {
        Instance = this; // simple singleton
        StarPoint = starPoint;
    }

    void Start()
    {
        if (abilityStatsAdaptor == null) { FindFirstObjectByType<AbilityStatsAdaptor>(); }
        abilityStatsAdaptor.OnAgilityTriggered += StarPointCalculation;
    }

    [SerializeField] TextMeshProUGUI starPointTMP;
    public int starPointArtmaMiktari = 5;

    [SerializeField] int starPoint = 100;
    public int StarPoint
    {
        get => starPoint; set
        {
            starPoint = value;
            if (StarPoint <= 0) StarPoint = 0;
            RefreshStatsUI();
        }
    }
    public void AddStarPoint(int amount) => StarPoint += amount;
    public void RemoveStarPoint(int amount) => StarPoint -= amount;

    void RefreshStatsUI()
    {
        Debug.Log("Refresing Stats UI");
        starPointTMP.text = starPoint.ToString();
    }


    void StarPointCalculation(object o, AbilityToStatArgs args)
    {
        StarPoint -= args.ability_arg.starPointCost;
        args.ability_arg.starPointCost += starPointArtmaMiktari;
        //args.ability_arg.currentTotalStatCount = GetFromCalculatedStats();
        args.ability_arg.currentTotalStatCount += args.ability_arg.modifier.modifierBaseValue;
        args.ability_arg.abButton.RefreshButton(args.ability_arg);
    }

}
