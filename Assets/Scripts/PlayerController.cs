using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public int lives = 3;


    void Start()
    {

    }

    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("COLLLLIDDDDEEEE");
        if (collision.gameObject.tag == "Enemy")
        {
            this.die();
        }
    }

    void die()
    {
        this.lives--;
        // Play death animation
        if (lives <= 0)
        {
            // Gameover
        }
        else
        {
            this.transform.position = Vector3.zero;
        }

    }
}
