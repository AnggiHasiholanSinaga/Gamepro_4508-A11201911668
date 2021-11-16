using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerScript : MonoBehaviour{
    public static int damageValue;
    Text damage;

    void Start()
    {
        damage = GetComponent<Text> ();
    }

    // Update is called once per frame
    void Update()
    {
        damage.text = "Damage Buff: + " + damageValue;
    }
}