using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed = 1;

    protected string horizontal;
    protected string vertical;
    protected Rigidbody2D rgbd2d;
    protected Animator anim;

    private Vector2 movement;

    // Use this for initialization
    void Start () {

    }
	
    protected Vector2 PlayerVelocity ()
    {
        float moveHorizontal = Input.GetAxisRaw(horizontal);
        float moveVertical = Input.GetAxisRaw(vertical);
        movement = new Vector2(moveHorizontal, moveVertical);
        return new Vector2(moveHorizontal, moveVertical) * speed;
    }

    protected float PlayerRotation ()
    {
        bool isWalking = movement != new Vector2();
        anim.SetBool("isWalking", isWalking);
        if (!isWalking)
        {
            return rgbd2d.rotation;
        }

        float result = Vector2.Angle(new Vector2(0, -1), movement);
        if (movement.x < 0)
        {
            result = -result;
        }
        return result;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        TrySwitchActivator(other, true);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        TrySwitchActivator(other, false);     
    }

    private void TrySwitchActivator(Collider2D other, bool on)
    {
        if (other.gameObject.CompareTag("Activator"))
        {
            Animator objAnim = other.gameObject.GetComponent<Animator>();
            if (objAnim == null)
            {
                Debug.Log("Activator animator isn't found");
            }
            objAnim.SetBool("Illuminated", on);
        }
        else
        {
            Debug.Log(string.Format("The attemp to switch game object without Activator tag, but with tag {0}", other.gameObject.tag));
        }

    }


}
