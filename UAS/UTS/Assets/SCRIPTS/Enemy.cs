using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour{
    public Animator animator;
    int currentHealth;
    public int maxHealth = 100;

    void Start(){
        currentHealth = maxHealth;
    }
    public void Damage(int damage){
        currentHealth -= damage;
        SFXScript.PlaySound("enemyHit");
        animator.SetTrigger("Hurt");
        if(currentHealth<=0){
            Die();
        }
    }
    void Die(){
        ScoreScript.scoreValue += 10;
        Debug.Log("Enemy Died!");
        animator.SetBool("isDead", true);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = true;
        Destroy(gameObject);
    }
}