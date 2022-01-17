using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroli : MonoBehaviour
{
    public float walkSpeed;

    [HideInInspector]
    public bool patroli;
    private bool mustTurn;
     
    public Rigidbody2D rb;
    public Transform groundCheckPos;
    public LayerMask groundLayer;
    public Collider2D bodycollider;

    void Start()
    {
        patroli = true;
    }

    void Update()
    {
        if (patroli){
            Patrol();
        }
    }

    private void FixedUpdate(){
        if (patroli){
            mustTurn = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer);
        }
    }

    void Patrol(){
        if (mustTurn || bodycollider.IsTouchingLayers(groundLayer)){
            Balik();
        }
        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }

    void Balik(){
        patroli = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        patroli = true;
    }
}