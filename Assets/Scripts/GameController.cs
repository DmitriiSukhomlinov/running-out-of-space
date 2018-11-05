using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    private bool gameWasEnded = false;

    void Start() {
    }

    void Update() {
    }

    public void EndGame() {
        gameWasEnded = true;
    }

    public bool isGameEnded() {
        return gameWasEnded;
    }

}
