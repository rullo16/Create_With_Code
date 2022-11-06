using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    
    
    void Start()
    {
        transform.position = new Vector3(3, 4, 1);
        transform.localScale = Vector3.one * 1.3f;
        
        Material material = Renderer.material;
        
        material.color = new Color(0.5f, 1.0f, 0.3f, 0.4f);
    }
    
    void Update()
    {
        
        transform.localScale += new Vector3(Random.Range(0,1), Random.Range(0,1),Random.Range(0,1));
        if(transform.position.z >= 50){
            transform.Translate(0.0f, 0.0f, -10.0f*Time.deltaTime);
        }else if(transform.position.z<-50 || transform.position.z<50){
            transform.Translate(0.0f, 0.0f, 10.0f*Time.deltaTime);
        }
        transform.Rotate(10.0f * Time.deltaTime, 0.0f, 0.0f);
    }
}
