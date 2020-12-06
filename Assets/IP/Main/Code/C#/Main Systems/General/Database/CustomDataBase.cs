using UnityEngine;
using System;
using UnityEditor;

namespace RogueDB
{
    public class CustomDataBase
    {

        public static T[] GetAllInstances<T>() where T : ScriptableObject
        {
            string[] guids = AssetDatabase.FindAssets("t:" + typeof(T).Name);  //FindAssets uses tags check documentation for more info
            T[] a = new T[guids.Length];
            for (int i = 0; i < guids.Length; i++)         //probably could get optimized 
            {
                string path = AssetDatabase.GUIDToAssetPath(guids[i]);
                a[i] = AssetDatabase.LoadAssetAtPath<T>(path);
            }

            return a;

        }

        public static GameObject GetPrefabInstance(string filter)
        {
            string[] guids = AssetDatabase.FindAssets(filter);
            GameObject[] temporaryguid = new GameObject[guids.Length];
            GameObject chosenObject = new GameObject();
            for(int i = 0; i < guids.Length;i++)
            {
                string path = AssetDatabase.GUIDToAssetPath(guids[i]);
                chosenObject = AssetDatabase.LoadAssetAtPath<GameObject>(path);
            }
            return chosenObject;
        }

    }
}
