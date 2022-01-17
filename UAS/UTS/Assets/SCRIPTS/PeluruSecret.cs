using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeluruSecret : MonoBehaviour
{
    float moveSpeed = 10f;
    Rigidbody2D rigid;

    PlayerMovementSecret target;
    Vector2 moveDirection;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<PlayerMovementSecret>();
        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        rigid.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 3f);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.name.Equals("Player")){
            Debug.Log("Hit!");
            Destroy(gameObject);
        }
    }
}
