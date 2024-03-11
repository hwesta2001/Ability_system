using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

[CreateAssetMenu(fileName = "AbilityContainer", menuName = "Abilities/AbilityContainer", order = 1)]
public class AbilityContainer : ScriptableObject
{
    [SerializeField] string AbilityContainerInfo = "This contianer carries... level abilities";
    [SerializeField] bool onValidateAutoGetAllinFolder;
    public List<AbilityBehaviour> abilities = new();
    string folderPath;

    void OnValidate()
    {
        if (!onValidateAutoGetAllinFolder) return;
        GetAllAbilitiesInFolder();
    }


    [ContextMenu("GetAllAbilitiesInFolder")]
    void GetAllAbilitiesInFolder()
    {
        SetFolderPath();
        abilities.Clear();
        string[] guids = AssetDatabase.FindAssets("t:prefab", new[] { folderPath });
        foreach (var item in guids)
        {
            AbilityBehaviour t = (AbilityBehaviour)AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(item), typeof(AbilityBehaviour));
            abilities.Add(t);
        }
    }

    void SetFolderPath()
    {
        folderPath = AssetDatabase.GetAssetPath(this);
        folderPath = folderPath.Replace("/" + this.name + ".asset", "");
    }
}
