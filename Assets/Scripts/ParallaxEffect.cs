using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    private float length, startPos;
    [SerializeField] private GameObject cam; // Assign via Inspector or auto-find
    public float parallaxEffect;

    void Start()
    {
        // Auto-assign main camera if not set in Inspector
        if (cam == null)
        {
            cam = Camera.main?.gameObject;
            if (cam == null)
                Debug.LogError("Assign a camera or ensure a Main Camera exists!");
        }

        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        // Guard clause if cam is still null
        if (cam == null) return;

        float temp = cam.transform.position.x * (1 - parallaxEffect);
        float distance = (cam.transform.position.x * parallaxEffect);
        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);

        if (temp > startPos + length)
            startPos += length;
        else if (temp < startPos - length)
            startPos -= length;
    }
}