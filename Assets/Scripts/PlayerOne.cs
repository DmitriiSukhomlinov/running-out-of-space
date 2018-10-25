using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOne : PlayerController
{
    public PlayerOne()
    {
        horizontal = "Horizontal_1";
        vertical = "Vertical_1";
    }

    // Use this for initialization
    void Start () {
        rgbd2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        rgbd2d.velocity = PlayerVelocity();
        rgbd2d.rotation = PlayerRotation();
    }
}
