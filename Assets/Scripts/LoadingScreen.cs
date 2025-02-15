using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    private void Start()
    {
        System.Threading.Thread.Sleep(3500);
        SceneManager.LoadScene("Level-1");
    }
}
