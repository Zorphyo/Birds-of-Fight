using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
