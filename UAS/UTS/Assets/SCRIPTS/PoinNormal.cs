using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoinNormal : MonoBehaviour{
   int increase = 10;
   Text score;

   private void Start(){
       score = GetComponent<Text>();
   }

   private void OnTriggerEnter2D(Collider2D collision){
       
       if(collision.tag == "Player"){
           GameObject player = collision.gameObject;
           PlayerCombatNormal playerScript = player.GetComponent<PlayerCombatNormal>();
           ScoreScript.scoreValue += increase;

           if(playerScript){
               playerScript.score += increase;
               Debug.Log("Score: +" + increase);
               Destroy(gameObject);
           }
       }
   }
}
