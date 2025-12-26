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

            // 1. Check for SpriteRenderer
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            if (spriteRenderer == null)
            {
                Debug.LogError($"No SpriteRenderer found on {gameObject.name}! Add one in the Inspector.", this);
                enabled = false;
                return;
            }

            // 2. Verify sprite is assigned
            if (spriteRenderer.sprite == null)
            {
                Debug.LogError($"SpriteRenderer on {gameObject.name} has no sprite assigned!", this);
                enabled = false;
                return;
            }

            // 3. Camera assignment
            if (cam == null)
            {
                Camera mainCamera = Camera.main;
                cam = mainCamera != null ? mainCamera.gameObject : null;

                if (cam == null)
                {
                    Camera[] cameras = FindObjectsByType<Camera>(FindObjectsSortMode.None);
                    if (cameras.Length > 0)
                    {
                        cam = cameras[0].gameObject;
                        Debug.LogWarning("Using first active camera found in scene.", this);
                    }
                    else
                    {
                        Debug.LogError("No cameras exist in the scene!", this);
                        enabled = false;
                        return;
                    }
                }
            }

            startPos = transform.position.x;
            length = spriteRenderer.bounds.size.x;
        }
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