using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenue : MonoBehaviour
{


    public GameObject container;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            container.SetActive(true);
            Time.timeScale = 0;
        }

    }

    public void resumeButton()
    {
        container.SetActive(false);
        Time.timeScale = 1;
    }

    public void menuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
