using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXScript : MonoBehaviour{
    public static AudioClip playerAttack, enemyHit, enemyDead;
    static AudioSource audioSrc;
    void Start()
    {
        playerAttack = Resources.Load<AudioClip>("playerAttack");
        enemyHit = Resources.Load<AudioClip>("enemyHit");
        enemyDead = Resources.Load<AudioClip>("enemyDead");

        audioSrc = GetComponent<AudioSource> ();
    }
    public static void PlaySound(string clip){
        switch (clip){
        case "playerAttack":
            audioSrc.PlayOneShot(playerAttack);
            break;
        case "enemyHit":
            audioSrc.PlayOneShot(enemyHit);
            break;
        case "enemyDeath":
            audioSrc.PlayOneShot(enemyDead);
            break;
        }
    }
}
