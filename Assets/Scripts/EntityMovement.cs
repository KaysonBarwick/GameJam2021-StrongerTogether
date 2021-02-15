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

    private Rigidbody2D rb2d;

    void Start()
    {
        this.rb2d = GetComponent<Rigidbody2D>();
        this.rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void FixedUpdate()
    {
        Vector2 move = new Vector2();
        switch (this.direction)
        {
            case Direction.Up:
                move.y = this.speed;
                break;
            case Direction.Down:
                move.y = -this.speed;
                break;
            case Direction.Left:
                move.x = -this.speed;
                break;
            case Direction.Right:
                move.x = this.speed;
                break;
        }
        this.rb2d.velocity = move;
    }

    public void changeDirection(Direction direction)
    {
        this.direction = direction;
    }

}
