using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightTimerController : MonoBehaviour {
    public LightController objectToAttach;
    public GameController gameController;

    private RectTransform myCanvas;
    private Image imageComponent;
    private bool timerIsGoing = false;
    private float timeHasPassed = 0f;

    private const float TIMER_DURATION = 15f;

    // Use this for initialization
    void Start() {
        myCanvas = GetComponentInParent<Canvas>().GetComponent<RectTransform>();
        imageComponent = GetComponent<Image>();

        //imageComponent.color = new Color(imageComponent.color.r, imageComponent.color.g, imageComponent.color.b, 0f);
        imageComponent.fillAmount = 0f;

        AttachToLight();

    }

    void LateUpdate() {
        if (gameController.isGameEnded()) {
            return;
        }

        if (timerIsGoing) {
            timeHasPassed += Time.deltaTime;
            imageComponent.fillAmount = 1f - timeHasPassed / TIMER_DURATION;
            if (timeHasPassed >= TIMER_DURATION) {
                imageComponent.fillAmount = 0f;
                objectToAttach.SetLightState(false);
            }
        }
    }

    public void TurnTimerState(bool state) {
        timerIsGoing = state;
    }

    private void AttachToLight () {
        Vector3 viewportPoint = Camera.main.WorldToViewportPoint(objectToAttach.transform.position);

        viewportPoint -= 0.5f * Vector3.one;
        viewportPoint.z = 0;

        Rect rect = myCanvas.rect;
        viewportPoint.x *= rect.width;
        viewportPoint.y *= rect.height;
        viewportPoint.y -= 35;

        transform.localPosition = viewportPoint;
    }
}
