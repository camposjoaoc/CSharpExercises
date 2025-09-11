using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] Transform enemy_Target;

    [SerializeField] private float enemy_SpawnRadius;

    [SerializeField] private List<GameObject> enemy_Prefabs = new();

    List<Enemy> spawnedEnemies = new();

    [SerializeField] private float enemy_SpawnRate;
    private float current_Enemyspawn = 0;

    void Update()
    {
        //Updating enemies
        for (int i = 0; i < spawnedEnemies.Count; i++)
        {
            spawnedEnemies[i].UpdateEnemy();
        }

        //Handle removal of enemies
        //checking what enemies should be destroyed
        for (int i = spawnedEnemies.Count - 1; i >= 0; i--)
        {
            if (spawnedEnemies[i].IsAlive() == false)
            {
                Destroy(spawnedEnemies[i].gameObject);
                spawnedEnemies.RemoveAt(i);
            }
        }

        //handle spawn enemies over time
        current_Enemyspawn += enemy_SpawnRate * Time.deltaTime;
        if (current_Enemyspawn >= 1)
        {
            SpawnEnemy();
            current_Enemyspawn = 0;
        }
    }

    public void SpawnEnemy()
    {
        // Spawn at random position within a circle
        Vector3 randomPosition = Random.insideUnitCircle.normalized * enemy_SpawnRadius;
        int rand = Random.Range(0, enemy_Prefabs.Count);

        GameObject newEnemy = Instantiate(enemy_Prefabs[rand], randomPosition, Quaternion.identity);

        Enemy newEnemyComponent = newEnemy.GetComponent<Enemy>();
        newEnemyComponent.Initialize(enemy_Target);
        spawnedEnemies.Add(newEnemyComponent);
    }
}