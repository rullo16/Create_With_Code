using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] obstacles;
    private int obstacleIndex;
    private Vector3 spawnPoint = new Vector3(25,0,0);
    private float startDelay = 2;
    private float repeatRate = 3;

    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnObstacle(){
        if(playerController.gameOver==false){
            obstacleIndex = Random.Range(0, obstacles.Length);
            Instantiate(obstacles[obstacleIndex], spawnPoint, transform.rotation);
        }
    }
}
