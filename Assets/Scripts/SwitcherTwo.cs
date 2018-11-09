using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitcherTwo : SwitcherController
{
    SwitcherTwo() : base(0.83f, 8.67f, new List<KeyCode> { KeyCode.Keypad1,
                                                  KeyCode.Keypad2,
                                                  KeyCode.Keypad3,
                                                  KeyCode.Keypad4,
                                                  KeyCode.Keypad5 }) { }

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        if (enemyLights.Length != 25)
        {
            Debug.Log(string.Format("Unexpected number of Second Switcher lights, expected: 25, current: {0}", enemyLights.Length));
        }
    }

    // Update is called once per frame
    void Update () {
        if (gameController.IsGameEnded()) {
            return;
        }

        UpdateControllerState();
    }

    //protected override float getAnyShit() {

    //    return 0f;
    //}

}
