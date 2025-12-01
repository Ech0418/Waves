using UnityEngine;

public class TextBoxScript : MonoBehaviour
{
    public GameObject textBox;
    void Start()
    {
        if (GameManager.instance.firstScene)
        {
            textBox.SetActive(true);
            GameManager.instance.firstScene = false;
        }
    }
    private void OnMouseDown()
    {
        textBox.SetActive(false);
    }
}
