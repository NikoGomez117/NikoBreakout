/// <summary>
/// This script defines the behavior for a simple object pooler for the breakout balls.
/// It holds a max of 10 balls and the balls repool themselves only if there's at least
/// 1 other ball still on screen.
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPooler : MonoBehaviour
{
    public static BallPooler instance;

    void Awake()
    {
        instance = this;
    }

    public Transform GetBall ()
    {
        foreach (Transform child in transform)
        {
            if (!child.gameObject.activeSelf)
            {
                return child;
            }
        }

        return null;
	}
}
