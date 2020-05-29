using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceScript : MonoBehaviour
{
    public int total_asteroides = 100;
    public float speed = 1.0f;
    
    public float cubeSize = 20f;

    public GameObject asteroid;
    void Start() {
       
        for (int i=0; i<total_asteroides; i++) {
            float spawnPointX = Random.Range(-cubeSize, cubeSize);
            float spawnPointY = Random.Range (-cubeSize, cubeSize);
            float spawnPointZ = Random.Range (-cubeSize, cubeSize);
            Vector3 spawnPos = new Vector3 (spawnPointX, spawnPointY, spawnPointZ);
            GameObject objeto = Instantiate(asteroid, spawnPos, Quaternion.identity);
            objeto.transform.parent = gameObject.transform;

            float spawnDirX = Random.Range(-1.0f, 1.0f);
            float spawnDirY = Random.Range(-1.0f, 1.0f);
            float spawnDirZ = Random.Range(-1.0f, 1.0f);
            float speed = Random.Range(-1.0f, 1.0f);
            Vector3 spawnDirection = new Vector3 (spawnDirX, spawnDirY, spawnDirZ);
            objeto.GetComponent<Rigidbody>().velocity = speed * spawnDirection;
        }   
    }
}

