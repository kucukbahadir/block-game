using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void PlayGame()
    {
        // Load the next scene in the build settings
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Quit the game
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
