using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Small script to hold all of the scene loading functions
public class LoadScenes : MonoBehaviour
{
    public void LoadGame() //Load main game
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void LoadMainMenu() //Load Main menu
    {
        SceneManager.LoadScene("MainMenu");
    }
}
