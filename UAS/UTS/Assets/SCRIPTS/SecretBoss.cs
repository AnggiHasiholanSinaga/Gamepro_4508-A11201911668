using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretBoss : MonoBehaviour
{
    [SerializeField]
    GameObject peluru;

    float fireRate;
    float nextFire;
    public HealthBar hp;
    int currentHealth;
    public int maxHealth = 500;

    void Start(){
        fireRate = .5f;
        nextFire = Time.time;
        currentHealth = maxHealth;
        hp.SetMaxHealth(maxHealth);
    }

    void Update(){
        canShoot();
    }
    void canShoot(){
        if(Time.time > nextFire){
            Instantiate(peluru, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }
    public void Damage(int damage){
        currentHealth -= damage;
        hp.SetHealth(currentHealth);
        SFXScript.PlaySound("enemyHit");
        if(currentHealth<=0){
            Die();
        }
    }
    void Die(){
        ScoreScript.scoreValue += 1000;
        GetComponent<Collider2D>().enabled = false;
        this.enabled = true;
        Destroy(gameObject);
    }
}