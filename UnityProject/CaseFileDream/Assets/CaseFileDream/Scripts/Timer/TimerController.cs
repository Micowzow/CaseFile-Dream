using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public Image timeRadial;
    public Respawning respawning;
    public PauseMenu pauseMenu;

    public float timeRemaining;

    public float addTime;
    public float maxTime = 5.0f;

    public void Awake() 
    {
        
    }
    void Start()
    {
        timeRemaining = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            timeRadial.fillAmount = timeRemaining / maxTime;
        }
        else
        {
            respawning.Die();
            pauseMenu.LoadMenu();
        }
    }

    public void AddTime()
    {
        timeRemaining += addTime;
        timeRadial.fillAmount = timeRemaining + addTime;

    }

    
}
