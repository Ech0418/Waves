using UnityEngine;

public class BoxTextBox : MonoBehaviour
{
    public GameObject textBox;
    private BoxCollider2D boxCollider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boxCollider = this.GetComponent<BoxCollider2D>();
        boxCollider.enabled = true;
        textBox.SetActive(true);
    }
    private void OnMouseDown()
    {
        boxCollider.enabled = false;
        textBox.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
