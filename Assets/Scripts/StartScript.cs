﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
   {
       if(Input.GetButton("Jump")){
           SceneManager.LoadScene("Asteroids");
       }
   }
}
