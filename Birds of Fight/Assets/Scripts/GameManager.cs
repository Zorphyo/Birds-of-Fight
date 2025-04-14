using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isPlayerTurn;
    public int playerTurn;
    public int opponentTurn;

    public static bool startPlayerTurn;

    // Start is called before the first frame update
    void Start()
    {
        isPlayerTurn = true;
        playerTurn = 1;
        opponentTurn = 0;

        startPlayerTurn = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpponentPlaysCard()
    {
        isPlayerTurn = false;
        playerTurn = 0;
        opponentTurn = 1;
    }

    public void PlayerPlaysCard()
    {
        isPlayerTurn = true;
        playerTurn = 1;
        opponentTurn = 0;
    }
}
