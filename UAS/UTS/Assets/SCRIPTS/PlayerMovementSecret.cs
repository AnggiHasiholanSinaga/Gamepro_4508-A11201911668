using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovementSecret : MonoBehaviour{
    
    public CharacterController2D control;
    public Animator animator;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    bool crouch = false;
    public HealthBar hp;
    int currentHealth;
    public int maxHealth = 100;

    void Start(){
        currentHealth = maxHealth;
        hp.SetMaxHealth(maxHealth);
    }

    void Update(){
       horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
       animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

       if(Input.GetButtonDown("Jump")){
           jump = true;
           animator.SetBool("isJump", true);
       }
       if(Input.GetButtonDown("Crouch")){
           crouch = true;
       }
       else if(Input.GetButtonUp("Crouch")){
           crouch = false;
       }
    }
    public void OnLanding(){
        animator.SetBool("isJump", false);
    }
    void FixedUpdate(){
        control.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
    private void OnTriggerEnter2D(Collider2D collision){
       if(collision.tag == "Peluru"){
           GameObject player = collision.gameObject;
           currentHealth -= 40;
           hp.SetHealth(currentHealth);
           if(currentHealth<=0){
               Die();
            }
        }
    }
    void Die(){
        Debug.Log("You Died!");
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        SceneManager.LoadScene("LoseSecret");
    }
}