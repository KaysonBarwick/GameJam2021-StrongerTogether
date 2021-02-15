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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.elapsedTime += Time.deltaTime;
        if(this.elapsedTime >= this.updateFrequency){
            this.elapsedTime -= this.updateFrequency;
            if(this.direction == Direction.Up){
                this.transform.Translate(new Vector3(0,this.tileSize,0), Space.World);
            } else if(this.direction == Direction.Down){
                this.transform.Translate(new Vector3(0,-this.tileSize,0), Space.World);
            } else if(this.direction == Direction.Left){
                this.transform.Translate(new Vector3(-this.tileSize,0,0), Space.World);
            } else if(this.direction == Direction.Right){
                this.transform.Translate(new Vector3(this.tileSize,0,0), Space.World);
            }
        }
    }

    public void changeDirection(Direction direction)
    {
        this.direction = direction;
    }

}
