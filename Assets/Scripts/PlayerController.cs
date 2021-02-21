using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int lives = 3;
    public int megaTime = 3;
    public int coolDownDots = 3;
    public int invulnerabilityTime = 1;

    public bool isInvulnerable = true;

    private PlayerController otherPlayer;
    private PlayerInput otherInput;
    private Color color;

    private float megaTimer = 0.0f;
    private int coolDownDotsEaten = 0;
    private float invulnerabilityTimer = 0f;
    private bool isMega = false;
    private bool isOnCooldown = true;

    private EntityMovement player;

    void Start()
    {
        this.player = this.GetComponent<EntityMovement>();
        this.color = this.GetComponent<SpriteRenderer>().color;
    }

    void Update()
    {
        if (this.isMega || this.isOnCooldown)
        {
            this.megaTimer += Time.deltaTime;
            if (this.isMega && this.megaTimer >= this.megaTime)
            {
                this.megaTimer = 0;
                this.split();
            }
            else if (this.isOnCooldown && this.coolDownDotsEaten >= this.coolDownDots)
            {
                this.megaTimer = 0;
                this.endCooldown();
            }
        }

        // invulnerability
        if (this.isInvulnerable)
        {
            this.invulnerabilityTimer += Time.deltaTime;
            if (this.invulnerabilityTimer >= this.invulnerabilityTime)
            {
                this.invulnerabilityTimer = 0f;
                this.isInvulnerable = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            if (this.isMega)
            {
                other.GetComponent<EntityMovement>().respawn();
            }
            else if (!this.isInvulnerable)
            {
                this.die();
            }
        }
        else if (other.tag == "Player" && !this.isOnCooldown && !this.isMega)
        {
            this.otherPlayer = other.GetComponentInParent<PlayerController>();
            if (!this.otherPlayer.isOnCooldown)
            {
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
        else if (other.tag == "Treat")
        {
            if (this.isOnCooldown)
            {
                this.coolDownDotsEaten++;
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

        this.gameObject.GetComponent<Animator>().SetBool("isMega", true);
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
        this.isInvulnerable = true;
        this.gameObject.GetComponent<Animator>().SetBool("isMega", false);
        this.GetComponent<SpriteRenderer>().color = new Color(this.color.r + 0.5f, this.color.g - 0.2f, this.color.b - 0.2f);
        this.isOnCooldown = true;
    }

    void endCooldown()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = this.color;
        this.isOnCooldown = false;
        this.coolDownDotsEaten = 0;
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
            this.isInvulnerable = true;
            this.player.respawn();
        }
    }
}
