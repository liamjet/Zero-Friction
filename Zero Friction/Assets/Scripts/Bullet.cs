using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    GameObject Player;


    private Rigidbody2D rb;
    public GameObject ship;
    private Movement movement;

    private float bulletSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
        movement = ship.GetComponent<Movement>();
        rb.velocity = movement.currentVelocity;    
        rb.AddForce(transform.right * bulletSpeed, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Collider2D>() != Player.GetComponent<Collider2D>())
        {
            Destroy(gameObject);
        }
        
    }
}
