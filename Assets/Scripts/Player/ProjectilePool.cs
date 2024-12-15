using System;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePool : MonoBehaviour
{
    public GameObject singleShotPrefab; // Singleshot prefab 
    public GameObject doubleShotPrefab; // Doubleshot prefab 
    public GameObject tripleShotPrefab; // tripleshot prefab 

    private List<GameObject> singleShotPool; // SingleShot pool
    private List<GameObject> doubleShotPool; // DoubleShot pool
    private List<GameObject> tripleShotPool; // TripleShot pool

    public int poolSize = 20; // pool size
    private void Start()
    {
        singleShotPool = new List<GameObject>();
        doubleShotPool = new List<GameObject>();
        tripleShotPool = new List<GameObject>();

        InitializePool(singleShotPool, singleShotPrefab);
        InitializePool(doubleShotPool, doubleShotPrefab);
        InitializePool(tripleShotPool, doubleShotPrefab);
    }


    private void InitializePool(List<GameObject> pool, GameObject prefab)
    {
        for (int j = 0; j < poolSize; j++)
        {

            GameObject projectile = Instantiate(prefab);
            projectile.SetActive(false);
            pool.Add(projectile);
        }
    }
    public GameObject GetProjectile(int type) // get projectile
    {
        List<GameObject> selectedPool = GetSelectedPool(type);
        foreach (GameObject projectile in selectedPool)
        {
            if (!projectile.activeInHierarchy)
            {
                projectile.SetActive(true);
                return projectile;
            }
        }
        return null;
    }
    private List<GameObject> GetSelectedPool(int type)
    {
        return type switch
        {
            0 => singleShotPool,
            1 => doubleShotPool,
            2 => tripleShotPool,
            _ => null,
        };
    }

    public void ReturnProjectile(GameObject projectile, int type)
    {
        projectile.SetActive(false); // deactivate projectile in pool
    }
}