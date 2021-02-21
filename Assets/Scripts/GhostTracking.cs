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
    public float velocity = 0;

    void Start()
    {
        this.rigidbody2D = this.GetComponent<Rigidbody2D>();
        this.ghost = this.GetComponent<EntityMovement>();
        this.targets = GameObject.FindGameObjectsWithTag("Player");
    }

    void Update()
    {
        this.velocity = this.rigidbody2D.velocity.magnitude;
        if (Mathf.Abs(this.ghost.lastTurnPosition.magnitude - this.transform.position.magnitude) >= this.delayDistance || velocity <= 0.1f)
            if (true)
            {
                List<EntityMovement.Direction> possibleDirections = new List<EntityMovement.Direction>();
                possibleDirections.Add(EntityMovement.Direction.Up);
                possibleDirections.Add(EntityMovement.Direction.Down);
                possibleDirections.Add(EntityMovement.Direction.Left);
                possibleDirections.Add(EntityMovement.Direction.Right);
                EntityMovement.Direction nextDirection = possibleDirections[Random.Range(0, possibleDirections.Count)];
                this.ghost.changeDirection(nextDirection, false, true);
            }
    }

}