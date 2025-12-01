using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
  public void CutScene()
    {
        if (GameManager.instance.isSolved1 & GameManager.instance.isSolved2 & GameManager.instance.isSolved3 & GameManager.instance.isSolved4)
        {
            SceneManager.LoadScene(6);

        }
    }
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