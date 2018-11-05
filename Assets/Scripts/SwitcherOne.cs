using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitcherOne : SwitcherController
{
    SwitcherOne() : base(-8.67f, -0.83f,
                               new List<KeyCode> { KeyCode.Alpha1,
                                           KeyCode.Alpha2,
                                           KeyCode.Alpha3,
                                           KeyCode.Alpha4,
                                           KeyCode.Alpha5 }) { }

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        if (enemyLights.Length != 25)
        {
            Debug.Log(string.Format("Unexpected number of First Switcher lights, expected: 25, current: {0}", enemyLights.Length));
        }
    }

    // Update is called once per frame
    void Update () {
        if (gameController.isGameEnded()) {
            return;
        }

        UpdateControllerState();
    }

    //protected override float getAnyShit() {

    //    return 0f;
    //}

}
