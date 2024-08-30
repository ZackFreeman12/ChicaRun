using UnityEngine.Events;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMaster : MonoBehaviour
{



    void Start()
    {
    }

    void Update()
    {
        if (Input.touchCount > 0 || Input.GetKeyDown("m"))
        {
            SceneManager.LoadSceneAsync("MainMenu");
        }
        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
