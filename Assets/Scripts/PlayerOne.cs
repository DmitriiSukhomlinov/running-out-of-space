using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOne : PlayerController {
    public PlayerOne() : base("Horizontal_1", 
                              "Vertical_1", 
                              "Action_1") { }
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
            rgbd2d.velocity = Vector3.zero;
            DisableAnimationAndMoving();
            return;
        }

        rgbd2d.velocity = PlayerVelocity();
        rgbd2d.rotation = PlayerRotation();
    }

    override public void DecreaseHealth() {
        healthBar.DecreaseValue(GameController.Player.First);
    }

}
