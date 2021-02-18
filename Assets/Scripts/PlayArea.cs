using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayArea : MonoBehaviour
{
    private float top;
    private float bottom;
    private float right;
    private float left;

    void Start()
    {
        Bounds bounds = this.GetComponent<Collider2D>().bounds;
        this.top = bounds.center.y + bounds.extents.y;
        this.bottom = bounds.center.y - bounds.extents.y;
        this.right = bounds.center.x + bounds.extents.x;
        this.left = bounds.center.x - bounds.extents.x;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Vector3 position = other.gameObject.GetComponent<Collider2D>().transform.position;
        if (position.y >= this.top)
        {
            other.gameObject.transform.position = new Vector2(position.x, this.bottom);
        }
        if (position.y <= this.bottom)
        {
            other.gameObject.transform.position = new Vector2(position.x, this.top);
        }
        if (position.x >= this.right)
        {
            other.gameObject.transform.position = new Vector2(this.left, position.y);
        }
        if (position.x <= this.left)
        {
            other.gameObject.transform.position = new Vector2(this.right, position.y);
        }
    }
}
