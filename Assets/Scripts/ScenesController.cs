using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
  
    public void OpenMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void NextLevel()
    {
        var index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index + 1);
    }

    public void CloseGame()
    {
        Application.Quit();
        Debug.Log("Close game");
    }
}