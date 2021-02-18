using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanAnimator : MonoBehaviour
{
    private EntityMovement entityMovement;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        entityMovement = GetComponent<EntityMovement>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        switch (entityMovement.direction)
        {
            case EntityMovement.Direction.Up:
                spriteRenderer.flipX = false;
                spriteRenderer.flipY = false;
                transform.rotation = Quaternion.Euler(Vector3.forward * 90);
                break;
            case EntityMovement.Direction.Down:
                spriteRenderer.flipX = false;
                spriteRenderer.flipY = true;
                transform.rotation = Quaternion.Euler(Vector3.forward * 270);
                break;
            case EntityMovement.Direction.Left:
                spriteRenderer.flipX = true;
                spriteRenderer.flipY = false;
                transform.rotation = Quaternion.Euler(Vector3.forward * 0);
                break;
            case EntityMovement.Direction.Right:
                spriteRenderer.flipX = false;
                spriteRenderer.flipY = false;
                transform.rotation = Quaternion.Euler(Vector3.forward * 0);
                break;
        }
    }
}
