using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] animalPrefabs; 
    private float startDelay = 5;
    private float spawnInterval = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InvokeRepeating("SpawnRandomAnimal",startDelay,spawnInterval);
    }

    void SpawnRandomAnimal(){
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPosition = new Vector3(Random.Range(-20, 20),0,20);
        Instantiate(animalPrefabs[animalIndex], spawnPosition, animalPrefabs[animalIndex].transform.rotation);

    }
}
