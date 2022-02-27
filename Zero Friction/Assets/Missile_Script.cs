using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile_Script : MonoBehaviour
{
    GameObject Player;


    private Rigidbody2D rb;
    public GameObject ship;
    private Movement movement;

    private float missileSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
        movement = ship.GetComponent<Movement>();
        rb.velocity = movement.currentVelocity;
        rb.AddForce(transform.right * missileSpeed, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Collider2D>() != Player.GetComponent<Collider2D>())
        {
            Destroy(gameObject);
        }

    }
}
