using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class AlbomController : MonoBehaviour
{
    public GameObject albom;
    public GameObject memo1;
    public GameObject memo2;
    public GameObject memo3;
    public GameObject memo4;
    private bool isAlbomOpened = false;
    public AudioSource generalMusic;
    public AudioSource albomSound;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        generalMusic.Play();
        albomSound.Stop();
    }
    public void play()
    {
        //generalMusic.Play();
        albom.SetActive(false);
        Time.timeScale = 1f;
        //audioSource.Stop();
    }
    public void pause()
    {
        if (!isAlbomOpened)
        {
            albomSound.Play();
            isAlbomOpened = true;
            albom.SetActive(true);
            if (GameManager.instance.isSolved1)
            {
                memo1.SetActive(true);
            }
            if (GameManager.instance.isSolved2)
            {
                memo2.SetActive(true);
            }
            if (GameManager.instance.isSolved3)
            {
                memo3.SetActive(true);
            }
            if (GameManager.instance.isSolved4)
            {
                memo4.SetActive(true);
            }
            //audioSource.Play();
        }
        else
        {
            albom.SetActive(false);
            isAlbomOpened = false;
        }
    }

}

