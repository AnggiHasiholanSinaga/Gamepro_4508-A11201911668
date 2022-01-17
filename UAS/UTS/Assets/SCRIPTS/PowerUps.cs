using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUps : MonoBehaviour{
   public int minIncrease = 10;
   public int maxIncrease = 30;
   int increase;
   Text damage;

   private void Start(){
       increase = Random.Range(minIncrease, maxIncrease);
       damage = GetComponent<Text>();
   }

   private void OnTriggerEnter2D(Collider2D collision){
       
       if(collision.tag == "Player"){
           GameObject player = collision.gameObject;
           PlayerCombat playerScript = player.GetComponent<PlayerCombat>();
           PowerScript.damageValue += increase;

           if(playerScript){
               playerScript.attackDamage += increase;
               Debug.Log("Your Damage Now: +" +increase);
               Destroy(gameObject);
           }
       }
   }
}
