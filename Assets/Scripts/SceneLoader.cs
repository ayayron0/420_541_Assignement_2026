using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    public void StartGame()
    {
        if (GameManager.Instance != null){

            GameManager.Instance.ResetScore();

        }

        SceneManager.LoadScene("SampleScene");
    }
}
