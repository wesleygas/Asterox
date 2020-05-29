using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour
{
 
   public float torque = 0.5f;
   public float speed = 1.0f;
 
   public GameObject bullet;
   public AudioManager audioManager;
   public float fireDelta = 0.5F;
   private float nextFire = 0.5F;
   private float myTime = 0.0F;

    void Start(){
        audioManager = FindObjectOfType<AudioManager>();
    }
   void FixedUpdate()
   {
 
       float v = -Input.GetAxis("Vertical");
       float h = Input.GetAxis("Horizontal");
       float p = Input.GetAxis("Fire2");
 
       Rigidbody rb = GetComponent<Rigidbody>();
 
       rb.AddForce(transform.forward * speed * p);
       rb.AddTorque(transform.up * torque * h);
       rb.AddTorque(transform.right * torque * v);
   }

   void Update()
   {
       myTime = myTime + Time.deltaTime;
 
       if (Input.GetButton("Fire1") && myTime > nextFire)
       {
           nextFire = myTime + fireDelta;
           GameObject instancia = Instantiate(bullet, transform.position + (transform.forward*2), transform.rotation) as GameObject;
           instancia.GetComponent<Rigidbody>().velocity = 20.0f * transform.forward;
           Destroy(instancia, 5.0f); // Destroi o tiro depois de 5 segundos
           nextFire = nextFire - myTime;
           myTime = 0.0F;
          audioManager.Play("shoot");
       }
   }
 
}

