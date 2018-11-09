using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class PlayerController : MonoBehaviour {
    public float speed = 1;
    public HealthBar healthBar;
    public GameController gameController;

    private readonly string HORIZONTAL;
    private readonly string VERTICAL;
    private readonly string ACTION;

    protected Rigidbody2D rgbd2d;
    protected Animator anim;
    protected Animation playerAnimation;

    private Vector2 movement;
    private bool switchLight = false;

    PlayerController() { }

    protected PlayerController(string h, string v, string a) {
        HORIZONTAL = h;
        VERTICAL = v;
        ACTION = a;
    }

    // Use this for initialization
    void Start () {}

    protected void TrySwitchLignt() {
        if (!switchLight) {
            return;
        }
    }

    protected void DisableAnimationAndMoving() {
        rgbd2d.velocity = Vector3.zero;
        anim.enabled = false;
    }

    protected Vector2 PlayerVelocity () {
        float moveHorizontal = Input.GetAxisRaw(HORIZONTAL);
        float moveVertical = Input.GetAxisRaw(VERTICAL);
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

    void OnTriggerEnter2D(Collider2D other) {
        TrySwitchActivator(other, true);
    }

    void OnTriggerStay2D(Collider2D other) {
        switchLight = Input.GetButtonDown(ACTION);
        if (!switchLight) {
            return;
        }

        Animator objAnim = getActivatorsAnimator(other);
        if (objAnim == null) {
            return;
        }

        objAnim.SetBool("TurnedOn", true);

    }

    void OnTriggerExit2D(Collider2D other) {
        TrySwitchActivator(other, false);     
    }

    private void TrySwitchActivator(Collider2D other, bool on) {
        Animator objAnim = getActivatorsAnimator(other);
        if (objAnim == null) {
            return;
        }

        objAnim.SetBool("Illuminated", on);
    }

    private Animator getActivatorsAnimator(Collider2D collider) {
        if (collider.gameObject.CompareTag("Activator")) {
            Animator objAnim = collider.gameObject.GetComponent<Animator>();
            if (objAnim == null) {
                Debug.Log("Activator animator isn't found");
            }
            return objAnim;
        } else {
            Debug.Log(string.Format("The attemp to switch game object without Activator tag, but with tag {0}", collider.gameObject.tag));
        }

        return null;
    }

    abstract public void DecreaseHealth();

}
