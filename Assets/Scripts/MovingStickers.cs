using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovingStickers: MonoBehaviour
{
    bool isMoveble;
    public GameObject form;
    public bool finish;
    private int sceneIndex;
    private bool isNear;

    public AudioSource photoSound;

    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (photoSound != null)
        {
            photoSound.Stop();
        }
        //Renderer renderer = GetComponent<Renderer>();
        isMoveble = true;
        finish = false;
    }

    void OnMouseDrag()
    {
        if (isMoveble)
        {
            
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePosition;
            transform.position = new Vector3(mousePosition.x, mousePosition.y, 0f);
        }
    }
    void OnMouseUp()
    {
        if (sceneIndex == 3)
        {
            isNear = Mathf.Abs(this.transform.position.x - form.transform.position.x) <= 3f &&
                     Mathf.Abs(this.transform.position.y - form.transform.position.y) <= 3f;
        }
        else
        {
            isNear = Mathf.Abs(this.transform.position.x - form.transform.position.x) <= 1f &&
                     Mathf.Abs(this.transform.position.y - form.transform.position.y) <= 1f;
        }
        if (isNear)
        {
            if (photoSound != null)
            {
                photoSound.Play();
            }
            this.GetComponent<SpriteRenderer>().sortingOrder = 2;
            this.transform.position = new Vector2(form.transform.position.x, form.transform.position.y);
            isMoveble = false;
            finish = true;
        }

    }
}
