using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour{

    public Animator animator;
    public HealthBar hp;
    public Transform attackPoint;
    public LayerMask enemyLayers;
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
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach(Collider2D enemy in hitEnemies){
            enemy.GetComponent<Enemy>().Damage(attackDamage);
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

    public void Damage(int damage){
        currentHealth -= damage;
        hp.SetHealth(currentHealth);
        animator.SetTrigger("Hurt");
        if(currentHealth<=0){
            Die();
        }
    }

    void Die(){
        Debug.Log("You Died!");
        animator.SetBool("isDead", true);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}