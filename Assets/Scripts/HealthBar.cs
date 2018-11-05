using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
    public GameController gameController;
    public Transform objectToFollow;

    private int healthValue = 100;
    private RectTransform myCanvas;
    private Image imageComponent;

    private float timeSinceDamage = 1f;

    // Use this for initialization
    void Start () {
        myCanvas = GetComponentInParent<Canvas>().GetComponent<RectTransform>();
        imageComponent = GetComponent<Image>();
    }
	
	// Update is called once per frame
	void LateUpdate() {
        if (gameController.isGameEnded()) {
            return;
        }

        HealthBarMooving();

        timeSinceDamage = Mathf.Min(1f, timeSinceDamage + Time.deltaTime);
        if (timeSinceDamage == 1f) {
            imageComponent.color = new Color(imageComponent.color.r, imageComponent.color.g, imageComponent.color.b, Mathf.Max(0f, imageComponent.color.a - Time.deltaTime));
        }
    }

    private void HealthBarMooving () {
        Vector3 viewportPoint = Camera.main.WorldToViewportPoint(objectToFollow.position);

        viewportPoint -= 0.5f * Vector3.one;
        viewportPoint.z = 0;

        Rect rect = myCanvas.rect;
        viewportPoint.x *= rect.width;
        viewportPoint.y *= rect.height;

        transform.localPosition = viewportPoint;
    }

    public void DecreaseValue() {
        if (healthValue == 0) {
            gameController.EndGame();
            return;
        }
        timeSinceDamage = 0f;
        healthValue--;
        imageComponent.fillAmount = healthValue * 0.01f;
        imageComponent.color = new Color(imageComponent.color.r, imageComponent.color.g, imageComponent.color.b, Mathf.Min(1f, imageComponent.color.a + Time.deltaTime * 3));
    }
}
