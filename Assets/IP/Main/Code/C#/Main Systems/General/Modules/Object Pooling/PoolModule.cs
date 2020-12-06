using System;
using System.Collections;
using UnityEngine;

public class PoolModule : MonoBehaviour
{
    public ObjectPoolSystem pooler;

    public void Start()
    {
        pooler = ObjectPoolSystem.Instance;
    }
}