using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab; // Prefab of the enemy to spawn
    private List<GameObject> enemies = new();
    private float timer;


    private void Start()
    {
        //SpawnMultipleEnemies(20);
        timer = 2;
    }

    private void Update()
    {
        if (timer >= 0)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                SpawnEnemy();
                timer = 2;
            }
        }

        // if (Input.GetKeyDown(KeyCode.E))
        // {
        //    timer = 2; 
        //       SpawnEnemy();
        // }

        enemies.RemoveAll(enemy => enemy == null);
        if (enemies.Count > 0)
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].transform.position += Vector3.down * Time.deltaTime;
            }
        }
    }

    private void SpawnEnemy()
    {
        GameObject newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        enemies.Add(newEnemy);
    }

    /*
    private void SpawnMultipleEnemies(int count)
    {
       for (int i = 0; i < count; i++)
       {
          SpawnEnemy();
       }
    }
    */
}