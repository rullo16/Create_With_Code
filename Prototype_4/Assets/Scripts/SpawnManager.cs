using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject[] powerUpPrefabs;
    private float spawnRange = 9;
    private int wave=1;
    public int enemyCount;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemies(wave);
        SpawnPowerUp(wave);
    }

    // Update is called once per frame
    void Update()
    {
        
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if(enemyCount==0){
            wave++;
            SpawnEnemies(wave);
            SpawnPowerUp(wave);
        }
    }

    private Vector3 GenerateRandomPosition(){
        float spawnPosX = Random.Range(-spawnRange,spawnRange);
        float spawnPosZ = Random.Range(-spawnRange,spawnRange);
        Vector3 spawnPos = new Vector3(spawnPosX,0,spawnPosZ);
        return spawnPos;
    }

    void SpawnEnemies(int n){
        for(int i = 0; i<n; i++){
            int randomEnemy = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[randomEnemy], GenerateRandomPosition(), enemyPrefabs[randomEnemy].transform.rotation);
        }
    }

    void SpawnPowerUp(int n){
        for(int i = 0; i<n; i++){
            int randomPowerUp = Random.Range(0, powerUpPrefabs.Length);
            Instantiate(powerUpPrefabs[randomPowerUp], GenerateRandomPosition(), powerUpPrefabs[randomPowerUp].transform.rotation);
        }
    }
}
