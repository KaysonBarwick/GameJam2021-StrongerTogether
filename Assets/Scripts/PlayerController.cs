using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public int lives = 3;
    public int megaTime = 3;
    public int coolDownTime = 3;

    private Color color;
    private bool isMega = false;
    private bool isOnCooldown = false;
    private float timer = 0.0f;
    private PlayerController otherPlayer;
    private PlayerInput otherInput;

    void Start()
    {
        this.color = this.GetComponent<SpriteRenderer>().color;
    }

    void Update()
    {
        if (this.isMega || this.isOnCooldown)
        {
            this.timer += Time.deltaTime;
            if (this.isMega && this.timer >= this.megaTime)
            {
                this.timer = 0;
                this.split();
            }
            else if (this.isOnCooldown && this.timer >= this.coolDownTime)
            {
                this.timer = 0;
                this.endCooldown();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            if (this.isMega)
            {
                other.transform.position = Vector2.zero;
            }
            else
            {
                this.die();
            }
        }
        else if (other.tag == "Player" && !this.isOnCooldown && !this.isMega)
        {
            this.otherPlayer = other.GetComponentInParent<PlayerController>();
            if (this.otherPlayer.isMega)
            {
                this.gameObject.SetActive(false);
            }
            else
            {
                this.combine();
            }
        }
    }


    void combine()
    {
        this.isMega = true;
        PlayerInput otherInput = this.otherPlayer.GetComponent<PlayerInput>();
        this.otherInput = this.gameObject.AddComponent<PlayerInput>();
        this.otherInput.upKey = otherInput.upKey;
        this.otherInput.downKey = otherInput.downKey;
        this.otherInput.leftKey = otherInput.leftKey;
        this.otherInput.rightKey = otherInput.rightKey;

        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 255, 0);
    }

    void split()
    {
        Destroy(this.otherInput);

        this.otherPlayer.gameObject.SetActive(true);
        this.otherPlayer.transform.position = this.transform.position;
        EntityMovement otherEntitiyMovement = this.otherPlayer.GetComponent<EntityMovement>();
        switch (this.GetComponent<EntityMovement>().direction)
        {
            case EntityMovement.Direction.Up:
                otherEntitiyMovement.changeDirection(EntityMovement.Direction.Down, true);
                break;
            case EntityMovement.Direction.Down:
                otherEntitiyMovement.changeDirection(EntityMovement.Direction.Up, true);
                break;
            case EntityMovement.Direction.Left:
                otherEntitiyMovement.changeDirection(EntityMovement.Direction.Right, true);
                break;
            case EntityMovement.Direction.Right:
                otherEntitiyMovement.changeDirection(EntityMovement.Direction.Left, true);
                break;
        }
        this.otherPlayer.startCooldown();
        this.otherPlayer = null;

        this.isMega = false;
        this.startCooldown();
    }

    void startCooldown()
    {
        this.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
        this.isOnCooldown = true;
    }

    void endCooldown()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = this.color;
        this.isOnCooldown = false;
    }

    void die()
    {
        this.lives--;
        // Play death animation
        if (lives <= 0)
        {
            Destroy(this.gameObject);
            // Gameover
        }
        else
        {
            this.transform.position = Vector3.zero;
        }

    }
}
