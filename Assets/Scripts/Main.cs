using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject startInstructionPanel;


    private void Start()
    {
        pausePanel.SetActive(false);
        startInstructionPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void PauseGame()
    {
        pausePanel.SetActive(true);
        AudioManager.instance.Play("Click");
        Time.timeScale = 0f;
        
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        AudioManager.instance.Play("Click");
        Time.timeScale = 1f;
    }
}

