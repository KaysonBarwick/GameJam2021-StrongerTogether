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
    public readonly float tileSize = 1;
    public float updateFrequency = 0.5f;

    public Direction direction;

    private float elapsedTime = 0;
    private int maxCollisions = 3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.elapsedTime += Time.deltaTime;
        if (this.elapsedTime >= this.updateFrequency)
        {
            this.elapsedTime -= this.updateFrequency;


            Vector2 move = new Vector2();
            switch (this.direction)
            {
                case Direction.Up:
                    move.y = this.tileSize;
                    break;
                case Direction.Down:
                    move.y = -this.tileSize;
                    break;
                case Direction.Left:
                    move.x = -this.tileSize;
                    break;
                case Direction.Right:
                    move.x = this.tileSize;
                    break;
            }

            RaycastHit2D[] collisions = new RaycastHit2D[this.maxCollisions];
            GetComponent<BoxCollider2D>().Cast(move, collisions, this.tileSize);
            bool hitWall = false;
            foreach (var collision in collisions)
            {
                if (collision && collision.collider.gameObject.layer == LayerMask.NameToLayer("Wall"))
                {
                    hitWall = true;
                }
            };
            if (!hitWall)
            {
                this.transform.Translate(move, Space.World);
            }
        }
    }

    public void changeDirection(Direction direction)
    {
        this.direction = direction;
    }

}
