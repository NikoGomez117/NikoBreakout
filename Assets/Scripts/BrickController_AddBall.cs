/// <summary>
/// This script is for the AddBall variant of a breakout brick. Additional functionalities include:
/// 
/// 1. Spawning a new ball when this brick is "destroyed."
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController_AddBall : BrickController
{
    [SerializeField]
    private Transform ball;

    protected override void OnCollisionEnter2D(Collision2D col)
    {
        base.OnCollisionEnter2D(col);

        if (col.gameObject.tag == "Ball")
        {
            Transform newBall = BallPooler.instance.GetBall();
            newBall.position = (Vector3)col.contacts[0].point - Vector3.forward;
            newBall.gameObject.SetActive(true);
        }
    }
}
