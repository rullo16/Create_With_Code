using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    private float speed = 10.0f;
    private float randX;
    private float randZ;
    private float randR;
    private float randG;
    private float randB;
    private float randA;
    private Vector3 targetPoint;
    private float upperBound = 5;
    private float rightBound = 20;
    private Material material;
    void Start()
    {
        transform.position = new Vector3(3, 4, 1);
        transform.localScale = Vector3.one * 1.3f;
        
        material = Renderer.material;
        
        material.color = new Color(0.5f, 1.0f, 0.3f, 0.4f);
        randX = Random.Range(-rightBound,rightBound);
        randZ = Random.Range(-upperBound,upperBound);

        InvokeRepeating("ChangeColor", 2, 5f);
    }
    
    void Update(){
        if(Vector3.Distance(transform.position , targetPoint) < 0.001f){
            randX = Random.Range(-rightBound,rightBound);
            randZ = Random.Range(-upperBound,upperBound);
            targetPoint = new Vector3(randX, 0.0f, randZ);
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPoint, speed*Time.deltaTime);
        
        transform.Rotate(10.0f * Time.deltaTime, 0.0f, 0.0f);
        
    }

    void ChangeColor(){
        randR = Random.Range(0.0f,1.0f);
        randG = Random.Range(0.0f,1.0f);
        randB = Random.Range(0.0f,1.0f);
        randA = Random.Range(0.0f,1.0f);

        material.color = new Color(randR,randG,randB,randA);
    }
}
