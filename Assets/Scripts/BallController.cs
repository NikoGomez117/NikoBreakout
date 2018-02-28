/// <summary>
/// This script defines the behavior for the breakout ball. It's functionalities include:
/// 
/// 1. Keeping track of the total number of balls on screen & RePool a off screen ball if there's 
///    one other on screen.
/// 2. Defining the speed, starting position, & spread (angle of firing on start and instantiation)
/// 3. Defining behavior when the ball interacts with the paddle.
/// 
/// The reflection of the ball off the paddle is based on which side it hit the paddle. The farther
/// the ball is from the center, the greater the angle of reflection.
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private static int numBalls = 0;
    
    public static void ResetNumBalls()
    {
        numBalls = 0;
    }

    private float speed = 10f;
    private float spread = 120.0f;
    private Vector3 startPos = new Vector3(0,-3.6f,-1);
    private Rigidbody2D myRigid;

    void Awake()
    {
        myRigid = GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        numBalls += 1;
        InitVel();
    }
    
    void FixedUpdate()
    {
        if (transform.position.y < startPos.y - 2f)
        {
            if (numBalls > 1)
            {
                numBalls -= 1;
                RePool();
            }
            else
            {
                Reset();
            }
        }
        else
        {
            myRigid.velocity = myRigid.velocity.normalized * speed;
        }
    }
    
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Paddle")
        {
            myRigid.velocity = (Quaternion.AngleAxis(
                (spread/2)*(col.transform.position.x-transform.position.x),
                Vector3.forward)
            * Vector2.up) * speed;
        }
    }

    void Reset()
    {
        transform.position = startPos;
        InitVel();
    }

    void RePool()
    {
        transform.localPosition = Vector3.zero;
        gameObject.SetActive(false);
    }

    void InitVel()
    {
        myRigid.velocity = (Quaternion.AngleAxis(Random.Range(-spread / 2, spread / 2), Vector3.forward)
            * Vector2.up) * speed;
    }
}
