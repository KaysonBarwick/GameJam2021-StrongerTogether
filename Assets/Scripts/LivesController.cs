using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesController : MonoBehaviour
{
    public PlayerController player;
    public int liveNumber;

    void Update()
    {
        if (player.lives < liveNumber)
        {
            Destroy(this.gameObject);
        }
    }
}
