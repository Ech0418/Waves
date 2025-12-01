using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public bool isPickedUp;
    private BoxCollider2D boxCollider;
    private void Start()
    {
        isPickedUp = false;
        boxCollider = GetComponent<BoxCollider2D>();
    }
    public void OnMouseDown()
    {
        if (!isPickedUp)
        {
            isPickedUp = true;
            boxCollider.enabled = false;
        }
    }
    void Update()
    {
        if (isPickedUp)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            mousePos.z = 0;
            transform.position = mousePos;
        }
    }
}
