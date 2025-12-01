using UnityEngine;

public class PlayGame : MonoBehaviour
{
    public GameObject panel;
    //public AudioSource audioSource;
    //public AudioSource generalMusic;
    private void Start()
    {
        //generalMusic.Play();
    }
    public void play()
    {
        //generalMusic.Play();
        panel.SetActive(false);
        Time.timeScale = 1f;
        //audioSource.Stop();
    }
    public void pause()
    {
        //generalMusic.Stop();
        panel.SetActive(true);
        //audioSource.Play();
        Time.timeScale = 0f;
    }
}