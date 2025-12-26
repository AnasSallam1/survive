using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                // Updated to use non-deprecated method
                _instance = FindFirstObjectByType<GameManager>(FindObjectsInactive.Exclude);

                if (_instance == null)
                {
                    Debug.LogError("No GameManager found in scene. Creating temporary instance.");
                    _instance = new GameObject("TempGameManager").AddComponent<GameManager>();
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        // Ensure only one instance exists
        if (_instance != null && _instance != this)
        {
            Debug.LogWarning("Duplicate GameManager detected. Destroying new instance.");
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject); // For scene persistence
        }
    }

    // Add your game management functionality below
    // Example:
    // public int Score { get; private set; }
    // public void AddScore(int points) => Score += points;

}