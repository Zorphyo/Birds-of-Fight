using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Small script to control bringing up and backing out of the instructions screen on the Main Menu
public class MainMenuHandler : MonoBehaviour
{
    public GameObject instructions;
    public void PullUpInstructions()
    {
        instructions.SetActive(true);
    }

    public void RemoveInstructions()
    {
        instructions.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
