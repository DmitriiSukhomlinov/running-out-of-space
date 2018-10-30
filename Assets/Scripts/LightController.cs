using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour {
    public PlayerController player;

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
        if (!LightState()) {
            return;
        }

        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance > 1) {
            return;
        }


        player.DecreaseHealth();
    }

    private void SetLightState(bool On) {
        spriteMask.enabled = On;
        anim.SetBool("lightOn", On);
    }

    private bool LightState() {
        return spriteMask.enabled;
    }



}
