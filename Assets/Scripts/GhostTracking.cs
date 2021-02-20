using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// private interface PathBlock {
//     int gScore
//     int hScore
//     int fScore

//     PathBlock parent
// }

public class GhostTracking : MonoBehaviour
{
    private GameObject[] targets;
    private EntityMovement ghost;
    private float delayDistance = 0.2f;
    new private Rigidbody2D rigidbody2D;


    void Start()
    {
        this.rigidbody2D = this.GetComponent<Rigidbody2D>();
        this.ghost = this.GetComponent<EntityMovement>();
        this.targets = GameObject.FindGameObjectsWithTag("Player");
    }

    void Update()
    {
        if (Mathf.Abs(this.ghost.lastTurnPosition.magnitude - this.transform.position.magnitude) >= this.delayDistance || this.rigidbody2D.velocity.magnitude == 0)
            if (true)
            {
                List<EntityMovement.Direction> possibleDirections = new List<EntityMovement.Direction>();
                possibleDirections.Add(EntityMovement.Direction.Up);
                possibleDirections.Add(EntityMovement.Direction.Down);
                possibleDirections.Add(EntityMovement.Direction.Left);
                possibleDirections.Add(EntityMovement.Direction.Right);
                // possibleDirections.Remove(this.ghost.direction);
                // if (this.ghost.direction != EntityMovement.Direction.Up && this.ghost.direction != EntityMovement.Direction.Down)
                // {
                //     Debug.Log("possible up/down");
                //     if (!this.ghost.castHitWall(EntityMovement.Direction.Up)) { possibleDirections.Add(EntityMovement.Direction.Up); }
                //     if (!this.ghost.castHitWall(EntityMovement.Direction.Down)) { possibleDirections.Add(EntityMovement.Direction.Down); }

                // }
                // if (this.ghost.direction != EntityMovement.Direction.Left && this.ghost.direction != EntityMovement.Direction.Right)
                // {
                //     Debug.Log("possible Right/Left");
                //     if (!this.ghost.castHitWall(EntityMovement.Direction.Left)) { possibleDirections.Add(EntityMovement.Direction.Left); }
                //     if (!this.ghost.castHitWall(EntityMovement.Direction.Right)) { possibleDirections.Add(EntityMovement.Direction.Right); }
                // }
                EntityMovement.Direction nextDirection = possibleDirections[Random.Range(0, possibleDirections.Count)];
                this.ghost.changeDirection(nextDirection, false, true);
            }
    }

}