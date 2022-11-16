using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBehaviour : MonoBehaviour
{

    private Transform target;
    private float speed = 15.0f;
    private bool homing;
    private float rocketStrength = 15.0f;
    private float aliveTimer = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(homing && target != null){
            Vector3 moveDirection = (target.position-transform.position).normalized;
            transform.position += moveDirection * speed *Time.deltaTime;
            transform.LookAt(target);
        }
    }

    void OnCollisionenter(Collision collision){
        if(target!=null){
            if(collision.gameObject.CompareTag(target.tag)){
                Rigidbody targetRb = collision.gameObject.GetComponent<Rigidbody>();
                Vector3 away = -collision.contacts[0].normal;
                targetRb.AddForce(away*rocketStrength, ForceMode.Impulse);
                Destroy(gameObject);
            }
        }
    }
    public void Fire(Transform newTarget){
        target = newTarget;
        homing  = true;
        Destroy(gameObject, aliveTimer);
    }
}
