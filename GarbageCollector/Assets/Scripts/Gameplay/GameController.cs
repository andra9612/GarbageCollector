using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameController : MonoBehaviour
{

    private bool isGameStarted = false;
    private ScoreController scoreController;
    private GameObject spawner;
    [SerializeField] private GameObject startText;
    [SerializeField] private GameObject endText;
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject restartBtn;
    [SerializeField] private GameObject pouseBtn;



    private void Start()
    {
        Time.timeScale = 0;
        spawner = GameObject.Find("Spawner");
        scoreController = GameObject.Find("ScoreCount").GetComponent<ScoreController>();
        DestroyerController.GarbageDestroyerObserver += CheckGameStatus;
    }

    private void Update()
    {
        if (Input.touchCount > 0 && !isGameStarted)
        {
            scoreText.text = "0";
            endText.SetActive(false);
            startText.SetActive(false);
            SetGameStatus(1,true,true);
        }
    }

    private void CheckGameStatus(bool value)
    {
        if (!value)
        {
            if(scoreController.Score < 0)
            {
                endText.SetActive(true);
                SetGameStatus(0,false,false);
            }
        }
    }


    private void SetGameStatus(int timeParam, bool gameStatusParam, bool spawnerEnabled)
    {
        if(spawner.transform.childCount > 0)
        {
            for (int i = 0; i < spawner.transform.childCount; i++)
            {
                Destroy(spawner.transform.GetChild(i));
            }
        }
        Time.timeScale = timeParam;
        isGameStarted = gameStatusParam;
        spawner.SetActive(spawnerEnabled);
        restartBtn.SetActive(spawnerEnabled);
        pouseBtn.SetActive(spawnerEnabled);
    }

    public void Pause()
    {
        if(Time.timeScale == 1)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
