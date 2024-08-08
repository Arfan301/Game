using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWeapons : MonoBehaviour
{
    [Header("Spawn Point")]
    public Transform spawnPoint;


    [Header("Weapon Types")]
    public GameObject gun;

    void Start()
    {
        Instantiate(gun, spawnPoint.position ,spawnPoint.rotation);
    }

}
