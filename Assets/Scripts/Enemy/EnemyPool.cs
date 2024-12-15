using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public GameObject enemyPrefabType1;
    public GameObject enemyPrefabType2;
    public GameObject enemyPrefabType3;
    private List<GameObject> enemyPoolType1;
    private List<GameObject> enemyPoolType2;
    private List<GameObject> enemyPoolType3;
    public int poolSize = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyPoolType1 = new List<GameObject>();
        enemyPoolType2 = new List<GameObject>();    
        enemyPoolType3 = new List<GameObject>();
        
        InitiatePool(enemyPoolType1, enemyPrefabType1);
        InitiatePool(enemyPoolType2, enemyPrefabType2);
        InitiatePool(enemyPoolType3, enemyPrefabType3);
    }
    private void InitiatePool(List<GameObject> pool, GameObject prefab) {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy= Instantiate(prefab);
            enemy.SetActive(false);
            pool.Add(enemy);
        }
    }
    public GameObject GetEnemy(int type){
        List<GameObject> selectEnemy = GetSelectedPool(type);
        foreach (GameObject enemy in selectEnemy)
        {
            if (!enemy.activeInHierarchy)
            {
                enemy.SetActive(true);
                return enemy;
            }
        }
        return null;
    }
    public List<GameObject> GetSelectedPool(int type){
        return type switch
        {
            0 => enemyPoolType1,
            1 => enemyPoolType2,
            2 => enemyPoolType3,
            _ => null,
        };
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
