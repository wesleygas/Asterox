using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BauzinScript : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other) {
        
        if (other.CompareTag("Player")) {
            Destroy(gameObject);
            Debug.Log("AAAi morri!");
            SceneManager.LoadScene("Final");
        }
    }
}
