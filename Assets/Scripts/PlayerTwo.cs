using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwo : PlayerController
{
    public PlayerTwo()
    {
        horizontal = "Horizontal_2";
        vertical = "Vertical_2";
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
