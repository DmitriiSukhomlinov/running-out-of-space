using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwo : PlayerController {
    PlayerTwo() : base("Horizontal_2", 
                       "Vertical_2", 
                       "Action_2") { }

    // Use this for initialization
    void Start () {
        rgbd2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerAnimation = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update() {
        if (gameController.IsGameEnded()) {
            return;
        }

        TrySwitchLignt();
    }

    void FixedUpdate () {
        if (gameController.IsGameEnded()) {
            DisableAnimationAndMoving();
            return;
        }

        rgbd2d.velocity = PlayerVelocity();
        rgbd2d.rotation = PlayerRotation();

    }

    override public void DecreaseHealth() {
        healthBar.DecreaseValue(GameController.Player.Second);
    }
}
