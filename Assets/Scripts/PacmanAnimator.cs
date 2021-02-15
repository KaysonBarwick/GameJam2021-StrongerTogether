using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanAnimator : MonoBehaviour
{
    private EntityMovement entityMovement;

    private void Start()
    {
        entityMovement = GetComponent<EntityMovement>();
    }
    // Update is called once per frame
    void Update()
    {
        switch (entityMovement.direction)
        {
            case EntityMovement.Direction.Up:
                transform.rotation = Quaternion.Euler(Vector3.forward * 90);
                break;
            case EntityMovement.Direction.Down:
                transform.rotation = Quaternion.Euler(Vector3.forward * 270);
                break;
            case EntityMovement.Direction.Left:
                transform.rotation = Quaternion.Euler(Vector3.forward * 180);
                break;
            case EntityMovement.Direction.Right:
                transform.rotation = Quaternion.Euler(Vector3.forward * 0);
                break;
        }
    }
}
