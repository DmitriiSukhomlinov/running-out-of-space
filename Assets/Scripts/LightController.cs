using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    private SpriteMask spriteMask;
    private Animator anim;

    // Use this for initialization
    void Start()
    {
        spriteMask = GetComponent<SpriteMask>();
        anim = GetComponent<Animator>();

        LightOn(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    private void LightOn(bool On)
    {
        spriteMask.enabled = On;
        anim.SetBool("lightOn", On);
    }

}
