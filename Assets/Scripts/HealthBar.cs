using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    // RectTransform is the 2D counterlart of Transform.
    private RectTransform ThisTransform = null;
    // Catch up speed.
    public float MaxSpeed = 10f;

    private void Awake()
    {
        // Get transform component.
        ThisTransform = GetComponent<RectTransform>();
    }
    // Start is called before the first frame update
    void Start()
    {
        // Set Start Health
        //if (Player.PlayerInstance)
        ThisTransform.sizeDelta = new Vector2(Mathf.Clamp(0, 0, 100), ThisTransform.sizeDelta.y);
        
    }

    // Update is called once per frame
    void Update()
    {
        // Update Health property.
        float HealthUpdate = 0f;
        // .
        //if ()
        HealthUpdate = Mathf.MoveTowards(ThisTransform.rect.width, 0, MaxSpeed);

        ThisTransform.sizeDelta = new Vector2(Mathf.Clamp(0, 0, 100), ThisTransform.sizeDelta.y);
    }
}
