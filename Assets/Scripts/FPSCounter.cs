using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour
{
    public float updateInterval = 0.5f;
    public Text fpsCounterText;

    private float accummulatedTime = 0.0f;
    private int frames = 0;
    private float timeLeft;
    private float fps;


    private void Start()
    {
        timeLeft = updateInterval;
    }


    private void Update()
    {
        timeLeft -= Time.deltaTime;
        accummulatedTime += Time.timeScale / Time.deltaTime;
        ++frames;

        if(timeLeft <= 0.0)
        {
            fps = (accummulatedTime / frames);
            timeLeft = updateInterval;
            accummulatedTime = 0.0f;
            frames = 0;
        }

        fpsCounterText.text = fps.ToString("F1") + " FPS";
    }
}
