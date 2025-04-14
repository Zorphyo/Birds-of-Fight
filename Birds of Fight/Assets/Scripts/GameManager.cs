using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isPlayerTurn;
    public int playerTurn;
    public int opponentTurn;

    // Start is called before the first frame update
    void Start()
    {
        isPlayerTurn = true;
        playerTurn = 1;
        opponentTurn = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
