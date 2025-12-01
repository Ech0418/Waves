using UnityEngine;

public class TextBoxScript : MonoBehaviour
{
    public GameObject textBox;
    private BoxCollider2D boxCollider;
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        if (GameManager.instance.firstScene)
        {
            textBox.SetActive(true);
            GameManager.instance.firstScene = false;
        }
    }
    private void OnMouseDown()
    {
        textBox.SetActive(false);
        boxCollider.enabled = false;
    }
}
