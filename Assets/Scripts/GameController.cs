using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour {
    public Text winMessage;

    public enum Player {
        First,
        Second
    }

    private bool gameWasEnded = false;

    void Start() {
        winMessage.enabled = false;
    }

    void Update() {
    }

    public void EndGame(Player player) {
        if (gameWasEnded) {
            return;
        }

        gameWasEnded = true;
        winMessage.text = string.Format("Player {0} wins!", player == Player.First ? "2" : "1");
        winMessage.enabled = true;
    }

    public bool IsGameEnded() {
        return gameWasEnded;
    }

}
