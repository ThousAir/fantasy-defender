using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public List<GameObject> enemyPrefabs = new List<GameObject>();

    public int healthChangePerRound = 5;
    public int enemiesFirstWave = 5;
    public int numAdditionalEnemiesPerWave = 3;
    private int numEnemiesThisWave;
    public float delayBetweenEnemies = 0.5f;
    public float delayBetweenWaves = 4f;
    public int wave = 0;
    // Start is called before the first frame update
    void Start()
    {
        numEnemiesThisWave = enemiesFirstWave;

        Coroutine coroutine = StartCoroutine(SpawnWave());

    }
    IEnumerator SpawnWave()
    {
        for (int i = 0; i < numEnemiesThisWave; i++)
        {
            
            GameObject prefabToSpawn = enemyPrefabs[Random.Range(0,3)];
            Instantiate(prefabToSpawn, WayPoints.staticWaypoint[0], Quaternion.identity);
            yield return new WaitForSeconds(delayBetweenEnemies);
        }
        numEnemiesThisWave += numAdditionalEnemiesPerWave;
        yield return new WaitForSeconds(delayBetweenWaves);
        enemyPrefabs[0].GetComponent<Enemy>().maxHealth += healthChangePerRound;
        enemyPrefabs[1].GetComponent<Enemy>().maxHealth += healthChangePerRound;
        enemyPrefabs[2].GetComponent<Enemy>().maxHealth += healthChangePerRound;

        wave++;
        if (wave >= 10)
        {
            BossSpawner();

        }
        else
        {
            StartCoroutine(SpawnWave());
        }
    }

    public void BossSpawner()
    {
       
        GameObject prefabToSpawn = enemyPrefabs[3];
        Instantiate(prefabToSpawn, WayPoints.staticWaypoint[0], Quaternion.identity);

    }

   
       
    }
