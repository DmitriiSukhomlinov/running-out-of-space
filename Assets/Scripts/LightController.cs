using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour {
    public PlayerController player;
    public LightTimerController lightTimer;
    public GameController gameController;

    private SpriteMask spriteMask;
    private Animator anim;

    // Use this for initialization
    void Start() {
        spriteMask = GetComponent<SpriteMask>();
        anim = GetComponent<Animator>();

        SetLightState(false);
    }

    // Update is called once per frame
    void Update() {
        if (gameController.isGameEnded()) {
            return;
        }

        if (!LightState()) {
            return;
        }

        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance > 1.5f) {
            return;
        }


        player.DecreaseHealth();
    }

    public void SetLightState(bool On) {
        spriteMask.enabled = On;
        anim.SetBool("lightOn", On);
        lightTimer.TurnTimerState(On);
    }

    private bool LightState() {
        return spriteMask.enabled;
    }



}
