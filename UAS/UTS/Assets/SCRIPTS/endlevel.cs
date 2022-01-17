using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class endlevel : MonoBehaviour{
    
    private void OnTriggerEnter2D(Collider2D collision){
       if(collision.tag == "Player"){
           GameObject player = collision.gameObject;
           SceneManager.LoadScene("Win");
           Destroy(gameObject);
       }
    }
}