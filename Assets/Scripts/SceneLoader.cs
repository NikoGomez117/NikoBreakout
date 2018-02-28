/// <summary>
/// Really basic script for loading scenes. Functionalities include:
/// 
/// 1. Loading a scene based on an index.
/// 
/// This script is always called by on click event triggers on the button UI
/// elements in the scene.
/// </summary>


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    public void LoadScene(string name)
    {
        BallController.ResetNumBalls();
        SceneManager.LoadScene(name);
    }
}
