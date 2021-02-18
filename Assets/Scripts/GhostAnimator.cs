using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAnimator : MonoBehaviour
{
    public SpriteRenderer bodyRenderer;
    public SpriteRenderer eyeRenderer;

    public Sprite eyeUp;
    public Sprite eyeDown;
    public Sprite eyeLeft;
    public Sprite eyeRight;

    private EntityMovement entityMovement;

    // Start is called before the first frame update
    void Start()
    {
        entityMovement = GetComponent<EntityMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (entityMovement.direction)
        {
            case EntityMovement.Direction.Up:
                bodyRenderer.flipX = false;
                eyeRenderer.sprite = eyeUp;
                break;
            case EntityMovement.Direction.Down:
                bodyRenderer.flipX = true;
                eyeRenderer.sprite = eyeDown;
                break;
            case EntityMovement.Direction.Left:
                bodyRenderer.flipX = true;
                eyeRenderer.sprite = eyeLeft;
                break;
            case EntityMovement.Direction.Right:
                bodyRenderer.flipX = false;
                eyeRenderer.sprite = eyeRight;
                break;
        }
    }
}
