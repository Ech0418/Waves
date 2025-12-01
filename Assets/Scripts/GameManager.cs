using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Флаги, которые помнят своё значение при перемещении между сценами
    public static GameManager instance;
    //Инициализация флагов
    public bool isSolved1;
    public bool isSolved2;
    public bool isSolved3;
    public bool isSolved4;
    public bool firstScene;

    private void Awake()
    {
        if (instance == null)
        {
            // Значение флагов по умолчанию
            firstScene = true;
            isSolved1 = false;
            isSolved2 = false;
            isSolved3 = false;
            isSolved4 = false;


            instance = this;
            DontDestroyOnLoad(gameObject);
           
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
}
