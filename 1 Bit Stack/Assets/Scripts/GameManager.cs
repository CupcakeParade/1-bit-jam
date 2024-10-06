using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class GameManager : MonoBehaviour
{
    public static event Action OnCubeSpawned = delegate { };


    private CubeSpawner[] spawners;
    private int spawnIndex;
    private CubeSpawner currentSpawner;

    private void Awake()
    {
        spawners = FindObjectsOfType<CubeSpawner>();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (MovingCube.CurrentCube != null)
            {
                MovingCube.CurrentCube.Stop();
            }

            spawnIndex = spawnIndex == 0 ? 1 : 0;
            currentSpawner = spawners[spawnIndex];

            currentSpawner.SpawnCube();
            OnCubeSpawned();
        }
    }
}
