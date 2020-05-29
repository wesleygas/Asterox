using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   public float base_speed = 1f; // velocidade do jogador
   private float speed;
   public float turn_speed = 2f;
   public float gravity = -9.8f; // valor da gravidade
   public LayerMask groundMask;
   CharacterController character;

   private Animator anim;
   Vector3 velocity;
   bool isGrounded;
 
   void Start()
   {
       character = gameObject.GetComponent<CharacterController>();
       anim = GetComponent<Animator>();

   }
 
   void Update()
   {
 
       // Verifica se encostando no chão (o centro do objeto deve ser na base)
       isGrounded = Physics.CheckSphere(transform.position, 0.2f, groundMask);
      
       // Se no chão e descendo, resetar velocidade
       if(isGrounded && velocity.y < 0.0f) {
           velocity.y = -1.0f;
       }
 
       float x = Input.GetAxis("Horizontal");
       float z = Input.GetAxis("Vertical");
       float run = Input.GetAxis("Fire3");
       if(run > .5f){
           if(z > 0) speed = base_speed*3f;
       }else{
            speed = base_speed*1f;
       } 

 
       anim.SetFloat("lr_vel", x);
       anim.SetFloat("fb_vel", z*speed);
       // Rotaciona personagem
       transform.Rotate(0, x * turn_speed * 10 * Time.deltaTime, 0);
 
       // Move personagem
       Vector3 move = transform.forward * z;
       character.Move(move * Time.deltaTime * speed);
 
       // Aplica gravidade no personagem
       velocity.y += gravity * Time.deltaTime;
       character.Move(velocity * Time.deltaTime);
 
   }
}

