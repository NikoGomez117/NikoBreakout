/// <summary>
/// This script defines the behavior of a simple breakout brick. Functionalities include:
/// 
/// 1. Keeping track of the total number of bricks in the scene.
/// 2. Defining behavior when the brick is hit by a ball.
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour
{
    public static int numBricks { get; private set; }

    void Awake()
    {
        numBricks += 1;
    }

    protected virtual void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ball")
        {
            numBricks -= 1;
            gameObject.SetActive(false);
        }
    }
}
