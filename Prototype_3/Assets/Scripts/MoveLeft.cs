using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{

    private float speed = 30;
    private float leftBound = -20;
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerController.gameOver == false){
            transform.Translate(Vector3.left*Time.deltaTime*speed);
        }

        if(transform.position.x < leftBound && gameObject.CompareTag("Obstacle")){
            Destroy(gameObject);
        }
    }
}
