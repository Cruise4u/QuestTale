using System;
using UnityEngine;
using EffectsLibrary;
using AbilityInterface;

public class SmokeProjectile : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ground"))
        {
            var smoke = FindObjectOfType<ObjectPoolSystem>().SpawnFromPool("SmokePool", gameObject.transform.position);
        }
    }
}
