using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

#if UNITY_EDITOR

public class RuleUpholder : AssetModificationProcessor
{
    public static string[] OnWillSaveAssets(string[] paths)
    {
        Debug.Log("OnWillSaveAssets");
        foreach (string path in paths)
            Debug.Log(path);
        //use this to force playing devs to obey the rules when creating levels

        
        return paths;
    }
}

#endif