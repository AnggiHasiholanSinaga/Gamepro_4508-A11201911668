using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour{
    public Animator animator;
    int currentHealth;
    public HealthBar hp;
    public int maxHealth = 100;

    void Start(){
        currentHealth = maxHealth;
        hp.SetMaxHealth(maxHealth);
    }
    public void Damage(int damage){
        currentHealth -= damage;
        hp.SetHealth(currentHealth);
        SFXScript.PlaySound("enemyHit");
        animator.SetTrigger("Hurt");
        if(currentHealth<=0){
            Die();
        }
    }
    void Die(){
        ScoreScript.scoreValue = 0;
        PowerScript.damageValue = 0;
        Debug.Log("Enemy Died!");
        animator.SetBool("isDead", true);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = true;
        SceneManager.LoadScene("Win");
    }
}