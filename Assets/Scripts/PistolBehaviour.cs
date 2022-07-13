using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PistolBehaviour : MonoBehaviour
{
    [SerializeField] TMP_Text score;
    [SerializeField] TMP_Text timer;
    [SerializeField] GameObject pauseMenu;
    Vector3 newPos;
    float y, z;
    [SerializeField] int newScore = 0;
    [SerializeField] int newTimer = 20;
    bool TimerChanging = false;
    bool GamePaused = false;

    public void Start()
    {
        score.text = newScore.ToString();
        timer.text = newTimer.ToString();
    }

    public void Update()
    {
        if (!TimerChanging && newTimer > 0)
        {
            StartCoroutine(StartTimer());  
        }
        if(newTimer == 0 )
        {
            GameOver();
        }
        
    }

    void GameOver()
    {
        pauseMenu.SetActive(true);
        GamePaused = true;
    }

    public void Restart()
    {
        GamePaused = false;
        newTimer = 20;
        newScore = 0;
        score.text = newScore.ToString();
        timer.text = newTimer.ToString();
        pauseMenu.SetActive(false);

    }
    IEnumerator StartTimer()
    {
        TimerChanging = true;
        yield return new WaitForSeconds(1);
        newTimer -= 1;
        timer.text = newTimer.ToString();
        TimerChanging = false;

    }

    public void OnDestroy()
    {
        if (!GamePaused)
        {
            newScore = int.Parse(score.text) + 5;
            score.text = newScore.ToString();


            y = Random.Range(-0.4f, 0.4f);
            z = Random.Range(-0.4f, 0.4f);

            newPos = new Vector3(0, y, z);

            this.gameObject.transform.GetChild(0).gameObject.transform.localPosition = newPos;

        }      
        
    }

    public void OnMiss()
    {
        if (!GamePaused)
        {
            Debug.Log("There");
            newScore = int.Parse(score.text) - 10;
            score.text = newScore.ToString();
        }
        
    }
}
