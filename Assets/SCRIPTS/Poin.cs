using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Poin : MonoBehaviour{
   int increase = 10;
   Text score;

   private void Start(){
       score = GetComponent<Text>();
   }

   private void OnTriggerEnter2D(Collider2D collision){
       
       if(collision.tag == "Player"){
           GameObject player = collision.gameObject;
           PlayerCombat playerScript = player.GetComponent<PlayerCombat>();
           ScoreScript.scoreValue += increase;

           if(playerScript){
               playerScript.score += increase;

               Debug.Log("Score: +" + increase);

               Destroy(gameObject);
           }
       }
   }
}
