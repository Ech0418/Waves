using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GoToCDMemory : MonoBehaviour
{
    public GameObject light1;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        light1.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // Метод, который вызывается при наведении курсора на объект
    public void OnMouseEnter()
    {
        if (!GameManager.instance.isSolved1)
        {
            light1.SetActive(true);
        }
    }
    // Метод, который вызывается, когда курсор покидает объект
    public void OnMouseExit()
    {
        light1.SetActive(false);
    }
    // Метод, который вызывается при клике на объект
    public void OnMouseDown()
    {
        if (!GameManager.instance.isSolved1)
        {
            GameManager.instance.isSolved1 = true;
            SceneManager.LoadScene(2);
        }

    }
}
