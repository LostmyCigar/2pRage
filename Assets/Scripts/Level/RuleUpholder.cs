using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

#if UNITY_EDITOR

/// <summary>
/// This is here so you can create levels that doesn conform to the rules
/// </summary>
public class RuleUpholder : AssetModificationProcessor
{
    public static string[] OnWillSaveAssets(string[] paths)
    {
        Debug.Log("OnWillSaveAssets");
        foreach (string path in paths)
            Debug.Log(path);


        
        return paths;
    }
}

#endif