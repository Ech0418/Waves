using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GoToGameMemory : MonoBehaviour
{
    public GameObject light;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        light.SetActive(false);
       
    }

    // Update is called once per frame
    void Update()
    {

    }
    // Метод, который вызывается при наведении курсора на объект
    public void OnMouseEnter()
    {
        if (!GameManager.instance.isSolved3)
        {
            light.SetActive(true);
        }
    }
    // Метод, который вызывается, когда курсор покидает объект
    public void OnMouseExit()
    {
        light.SetActive(false);
    }
    // Метод, который вызывается при клике на объект
    public void OnMouseDown()
    {
        if (!GameManager.instance.isSolved3)
        {
            GameManager.instance.isSolved3 = true;
            SceneManager.LoadScene(3);
        }

    }
}
