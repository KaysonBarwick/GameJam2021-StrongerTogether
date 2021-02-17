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

    private Direction nextDirection;
    private Rigidbody2D rigidbody2D;
    private BoxCollider2D boxCollider2D;
    public ContactFilter2D wallFilter;

    void Start()
    {
        this.nextDirection = this.direction;
        this.boxCollider2D = GetComponent<BoxCollider2D>();

        this.rigidbody2D = GetComponent<Rigidbody2D>();
        this.rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void FixedUpdate()
    {
        if (this.direction != this.nextDirection)
        {
            RaycastHit2D[] collisions = new RaycastHit2D[3];
            bool hitWall = this.boxCollider2D.Cast(getDirectionVector(this.nextDirection), this.wallFilter, collisions, this.boxCollider2D.size.x / 2) > 0;
            if (!hitWall) { this.direction = this.nextDirection; }
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

    public void changeDirection(Direction direction, bool force = false)
    {
        if (force)
        {
            this.direction = direction;
            this.nextDirection = direction;
            return;
        }

        switch (direction)
        {
            case Direction.Up:
                if (this.direction != Direction.Down)
                {
                    this.nextDirection = Direction.Up;
                }
                break;
            case Direction.Down:
                if (this.direction != Direction.Up)
                {
                    this.nextDirection = Direction.Down;
                }
                break;
            case Direction.Left:
                if (this.direction != Direction.Right)
                {
                    this.nextDirection = Direction.Left;
                }
                break;
            case Direction.Right:
                if (this.direction != Direction.Left)
                {
                    this.nextDirection = Direction.Right;
                }
                break;
        }
    }
}
