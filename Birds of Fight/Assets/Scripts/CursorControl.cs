using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Small script to control when the player can use their mouse and when they can't. I mainly used this to turn the mouse off when cards are being removed or added so nothing wonky happens
public class CursorControl : MonoBehaviour
{
    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}
