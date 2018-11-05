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
    }

    // Update is called once per frame
    void Update() {
        if (gameController.isGameEnded()) {
            return;
        }

        TrySwitchLignt();
    }

    void FixedUpdate () {
        if (gameController.isGameEnded()) {
            rgbd2d.velocity = Vector3.zero;
            return;
        }

        rgbd2d.velocity = PlayerVelocity();
        rgbd2d.rotation = PlayerRotation();

    }
}
