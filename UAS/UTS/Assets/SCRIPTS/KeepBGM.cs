using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepBGM : MonoBehaviour
{
    void Awake(){
        GameObject[]musicObj = GameObject.FindGameObjectsWithTag("BGM");
        if(musicObj.Length > 1){
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
