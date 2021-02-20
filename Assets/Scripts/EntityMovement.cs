using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMovement : MonoBehaviour
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }
    public float speed = 1;
    public Direction direction;
    public ContactFilter2D wallFilter;


    public Vector3 lastTurnPosition { get; private set; }
    private Direction nextDirection;
    private Vector2 respawnPosition;

    new private Rigidbody2D rigidbody2D;
    private BoxCollider2D boxCollider2D;

    void Start()
    {
        this.nextDirection = this.direction;
        this.lastTurnPosition = this.transform.position;
        this.boxCollider2D = GetComponent<BoxCollider2D>();
        this.respawnPosition = this.transform.position;

        this.rigidbody2D = GetComponent<Rigidbody2D>();
        this.rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void FixedUpdate()
    {
        if (this.direction != this.nextDirection && !this.castHitWall(this.nextDirection))
        {
            this.direction = this.nextDirection;
            this.lastTurnPosition = this.transform.position;
        }
        this.rigidbody2D.velocity = getDirectionVector(this.direction);
    }

    public Vector2 getDirectionVector(Direction direction)
    {
        switch (direction)
        {
            case Direction.Up:
                return Vector2.up * this.speed;
            case Direction.Down:
                return Vector2.down * this.speed;
            case Direction.Left:
                return Vector2.left * this.speed;
            case Direction.Right:
                return Vector2.right * this.speed;
        }
        return new Vector2(0, 0);
    }

    public void changeDirection(Direction direction, bool force = false, bool noTurnAround = false)
    {
        if (force)
        {
            this.direction = direction;
            this.nextDirection = direction;
            return;
        }

        if (noTurnAround)
        {
            switch (direction)
            {
                case Direction.Up:
                    if (this.direction == Direction.Down) { return; }
                    break;
                case Direction.Down:
                    if (this.direction == Direction.Up) { return; }
                    break;
                case Direction.Left:
                    if (this.direction == Direction.Right) { return; }
                    break;
                case Direction.Right:
                    if (this.direction == Direction.Left) { return; }
                    break;
            }

        }
        this.nextDirection = direction;
    }

    public bool castHitWall(Direction direction)
    {
        return this.boxCollider2D.Cast(getDirectionVector(direction), this.wallFilter, new RaycastHit2D[3], 0.1f) > 0;
    }

    public void respawn()
    {
        this.transform.position = this.respawnPosition;
    }

}
