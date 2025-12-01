using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour
{
    public GameObject[] stickers;
    public Animator waves;
    public GameObject wave;
    private void Start()
    {
        wave.SetActive(false);
        waves.StopPlayback();
    }
    IEnumerator waitAnimation()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);
    }
    private void Update()
    {
      if(AllDone() == true)
        {
            wave.SetActive(true);
            Debug.Log("aaa");
            waves.Play("Win");
            StartCoroutine(waitAnimation());
            
        }
    }

    public bool AllDone()
    {
        for(int i = 0; i < stickers.Length; i++)
        {
            if (!stickers[i].GetComponent<MovingStickers>().finish)
            {
                waves.StopPlayback();
                return false;
            }
        }
        return true; 
    }
}
