using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private EntityMovement entityMovement;
    public KeyCode upKey = KeyCode.W;
    public KeyCode downKey = KeyCode.S;
    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;

    // Start is called before the first frame update
    void Start()
    {
        this.entityMovement = GetComponent<EntityMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(this.upKey))
        {
            this.entityMovement.changeDirection(EntityMovement.Direction.Up);
        }
        else if (Input.GetKeyDown(this.downKey))
        {
            this.entityMovement.changeDirection(EntityMovement.Direction.Down);
        }
        else if (Input.GetKeyDown(this.leftKey))
        {
            this.entityMovement.changeDirection(EntityMovement.Direction.Left);
        }
        else if (Input.GetKeyDown(this.rightKey))
        {
            this.entityMovement.changeDirection(EntityMovement.Direction.Right);
        }
    }
}
