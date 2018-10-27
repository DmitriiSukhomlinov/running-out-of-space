using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwo : PlayerController
{
    PlayerTwo() : base("Horizontal_2", 
                       "Vertical_2", 
                       "Action_2", 
                       new List<KeyCode> { KeyCode.Alpha1,
                                           KeyCode.Alpha2,
                                           KeyCode.Alpha3,
                                           KeyCode.Alpha4,
                                           KeyCode.Alpha5 }) { }

    // Use this for initialization
    void Start () {
        rgbd2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        TrySwitchLignt();
    }

    void FixedUpdate ()
    {
        rgbd2d.velocity = PlayerVelocity();
        rgbd2d.rotation = PlayerRotation();

    }
}
