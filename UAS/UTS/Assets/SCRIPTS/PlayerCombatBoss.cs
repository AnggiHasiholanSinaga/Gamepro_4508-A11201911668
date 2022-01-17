using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCombatBoss : MonoBehaviour{

    public Animator animator;
    public HealthBar hp;
    public Transform attackPoint;
    public LayerMask bossLayer;
    public int score = 0;
    int currentHealth;
    public int maxHealth = 100;
    public float attackRange = 0.5f;
    public int attackDamage = 20;
    public float attackRate = 10f;
    float nextAttackTime = 0f;
    
    void Update(){
        if(Time.time >= nextAttackTime){
            if(Input.GetButtonDown("Fire1")){
            SFXScript.PlaySound("playerAttack");
            Attack();
            nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }
    void Attack(){
        animator.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, bossLayer);
        foreach(Collider2D boss in hitEnemies){
            boss.GetComponent<Boss>().Damage(attackDamage);
        }
    }
    void OnDrawGizmosSelected(){
        if(attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    void Start(){
        currentHealth = maxHealth;
        hp.SetMaxHealth(maxHealth);
    }
    private void OnTriggerEnter2D(Collider2D collision){
       if(collision.tag == "Boss"){
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
        animator.SetBool("isDead", true);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        SceneManager.LoadScene("Lose");
    }
}