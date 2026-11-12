using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    [SerializeField] private string gameSceneName;

    public void Play()
    {
        SceneManager.LoadScene(gameSceneName);
    }
    public void Quit()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
}
