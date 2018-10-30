using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    public Transform objectToFollow;

    public int healthValue = 100;
    private RectTransform myCanvas;
    private Image imageComponent;

    // Use this for initialization
    void Start () {
        myCanvas = GetComponentInParent<Canvas>().GetComponent<RectTransform>();
        imageComponent = GetComponent<Image>();
    }
	
	// Update is called once per frame
	void LateUpdate() {
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

            return;
        }
        healthValue--;
        imageComponent.fillAmount = healthValue * 0.01f;
    }
}
