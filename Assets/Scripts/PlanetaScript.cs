using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlanetaScript : MonoBehaviour
{
    public bool worthy = false;
    private int asteroidsDestroyed = 0;
   void OnTriggerEnter(Collider other) {
       if (worthy && other.CompareTag("Player")) {
           SceneManager.LoadScene("Planet");
       }else if(!worthy){
           FindObjectOfType<AudioManager>().Play("notWorthy");
       }
   }

   void Update(){
       if(!worthy && asteroidsDestroyed > 0 && Input.GetButton("Jump")){
           SceneManager.LoadScene("Asteroids");
       }
   }

   void asteroidDestroyed(){
       Debug.Log("Received Message");
        asteroidsDestroyed++;
        worthy = asteroidsDestroyed == 1;
        if(asteroidsDestroyed > 1){
            GameObject.Find("/Planeta/Canvas/tryAgain").GetComponent<Text>().text = "Para tentar novamente, aperte espaço";
        }

   }
}

