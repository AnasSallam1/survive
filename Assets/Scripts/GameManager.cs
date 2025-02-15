using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // A static private variable to hold the reference to this Game Manager instance.
    private static GameManager _instance;
    // A public static Property to allow other classes to get the refernece.
    public static GameManager Instance {
        get { 
            if (_instance == null)
                Debug.LogError("ERROR: No GameManager exists in scene.");
            return _instance; 
        }
    }

    // Set the _instance reference at the soonest opportunity when the game starts.
    private void Awake() => _instance = this; 
}
