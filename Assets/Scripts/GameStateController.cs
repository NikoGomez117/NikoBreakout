/// <summary>
/// This script controls the "gamestate." Functionalities include:
/// 
/// 1. Checking for the win condition and spawning the menu to either restart the
///    game or go back to the main menu.
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateController : MonoBehaviour {

    [SerializeField]
    private GameObject endMenu;

    void Update ()
    {
        if (BrickController.numBricks == 0 && !endMenu.activeSelf)
        {
            endMenu.SetActive(true);
        }
    }
}
