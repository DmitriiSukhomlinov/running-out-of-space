using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public /*abstract*/ class SwitcherController : MonoBehaviour {
    
    private enum Side {
        Top = 0,
        Right,
        Bottom,
        Left
    }

    private enum MovingState {
        InsideWall, 
        OutsideWall,
        NoMoving
    }

    //private Animator anim;


    private static readonly float DURATION = 5f; 
    private readonly float SIZE = 0.45f;
    private readonly float TOP = 3.67f;
    private readonly float BOTTOM = -3.67f;
    private readonly float LEFT;
    private readonly float RIGHT;

    private MovingState currentState;
    private Side currentSide = Side.Left;
    private Side prepearingSide = Side.Right;
    private float timeRemaining = DURATION;

    private float newX = 0f;
    private float newY = 0f;
    private int newEulerZ = 0;

    public GameObject[] enemyLights;
    public GameObject this[int x, int y] {
        get {
            return enemyLights[((x - 1) * 5) + y];
        }
        set 
        {
            enemyLights[((x - 1) * 5) + y] = value;
        }
    }

    protected SwitcherController() { }
    protected SwitcherController(float left, float right) {
        LEFT = left;
        RIGHT = right;
    }

    // Use this for initialization
    void Start ()
    {
        Random.InitState(System.DateTime.Now.Millisecond);
        currentSide = (Side)Random.Range(0, 4);
        currentState = MovingState.NoMoving;
        newX = LEFT;
        newY = TOP;
        //anim = GetComponent<Animator>();
    }

    private void Awake() {
        SwitchPosition();
    }

    // Update is called once per frame
    protected void UpdateControllerState() {
        if (currentState != MovingState.NoMoving) {
            PositionChanging();
        }
        if (timeRemaining > 0) {
            //Debug.Log("Waitting..." + timeRemaining);
            timeRemaining -= Time.deltaTime;
            if (timeRemaining <= 0) {
                timeRemaining = DURATION;
                SwitchPosition();
            }
        }
    }

    void SwitchPosition() {
        do {
            Random.InitState(System.DateTime.Now.Millisecond);
            prepearingSide = (Side)Random.Range(0, 4);
        } while (prepearingSide == currentSide);

        switch (prepearingSide) {
            case Side.Top:
                Random.InitState(System.DateTime.Now.Millisecond);
                newX = Random.Range(LEFT, RIGHT);
                newY = TOP + SIZE;
                newEulerZ = 270;
                break;
            case Side.Right:
                newX = RIGHT + SIZE;
                Random.InitState(System.DateTime.Now.Millisecond);
                newY = Random.Range(BOTTOM, TOP);
                newEulerZ = 180;
                break;
            case Side.Bottom:
                Random.InitState(System.DateTime.Now.Millisecond);
                newX = Random.Range(LEFT, RIGHT);
                newY = BOTTOM - SIZE;
                newEulerZ = 90;
                break;
            case Side.Left:
                newX = LEFT - SIZE;
                newY = Random.Range(BOTTOM, TOP);
                newEulerZ = 0;
                break;
        }

        currentState = MovingState.InsideWall;
    }

    void PositionChanging() {
        int coef = currentState == MovingState.InsideWall ? (-1) : 1;
        Mooving(coef);
    }

    private void Mooving (int coef) {
        Vector3 newPos = transform.position;
        bool teleportPoint = false;
        switch(currentSide) {
            case Side.Top:
                newPos = new Vector3(newPos.x, newPos.y - (coef * Time.deltaTime), newPos.z);
                if (currentState == MovingState.InsideWall && newPos.y >= TOP + SIZE) {
                    teleportPoint = true;
                } else if (currentState == MovingState.OutsideWall && newPos.y <= TOP) {
                    currentState = MovingState.NoMoving;
                }
                break;
            case Side.Right:
                newPos = new Vector3(newPos.x - (coef * Time.deltaTime), newPos.y, newPos.z);
                if (currentState == MovingState.InsideWall && newPos.x >= RIGHT + SIZE) {
                    teleportPoint = true;
                } else if (currentState == MovingState.OutsideWall && newPos.x <= RIGHT) {
                    currentState = MovingState.NoMoving;
                }
                break;
            case Side.Bottom:
                newPos = new Vector3(newPos.x, newPos.y + (coef * Time.deltaTime), newPos.z);
                if (currentState == MovingState.InsideWall && newPos.y <= BOTTOM - SIZE) {
                    teleportPoint = true;
                } else if (currentState == MovingState.OutsideWall && newPos.y >= BOTTOM) {
                    currentState = MovingState.NoMoving;
                }
                break;
            case Side.Left:
                newPos = new Vector3(newPos.x + (coef * Time.deltaTime), newPos.y, newPos.z);
                if (currentState == MovingState.InsideWall && newPos.x <= LEFT - SIZE) {
                    teleportPoint = true;
                } else if (currentState == MovingState.OutsideWall && newPos.x >= LEFT) {
                    currentState = MovingState.NoMoving;
                }
                break;
        }
        if (teleportPoint) {
            currentSide = prepearingSide;
            transform.position = new Vector3(newX, newY, 0); ;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, newEulerZ));
            currentState = MovingState.OutsideWall;

        } else {
            transform.position = newPos;
        }
    }

    //protected abstract float getAnyShit();
}
