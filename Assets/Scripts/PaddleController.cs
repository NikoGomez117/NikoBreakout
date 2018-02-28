/// <summary>
/// This script defines the behavior of the paddle. It's functionalities include:
/// 
/// 1. Defining the range of positions over which the paddle can move.
/// 2. Managing player input by setting the x position to the mouse x position in world space.
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour {
    [SerializeField]
    private float maxDis = 4f;
    [SerializeField]
    private float mimDis = -4f;

    void Update()
    {
        ManageInput();
    }

    void ManageInput()
    {
        Camera c = Camera.main;
        float newPaddlePosition = c.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0f, c.nearClipPlane)).x;
        transform.position = (transform.position.y * Vector3.up + transform.position.z * Vector3.forward)
            + Mathf.Min(maxDis, Mathf.Max(mimDis, newPaddlePosition)) * Vector3.right;
    }
}
