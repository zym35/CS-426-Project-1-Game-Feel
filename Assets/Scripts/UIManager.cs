using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    
    public bool isGameRunning;
    public GameObject pauseMenu;
    public PaletteScriptableObject palette;
    public Color backgroundColor, squareColor, circleColor, clickColor;
    public SpriteRenderer background;

    public bool enableTrail = true, enableSlowMo = true, enableAudio = true;

    public void ToggleTrail()
    {
        enableTrail = !enableTrail;
        foreach (var a in FindObjectsOfType<TrailRenderer>())
        {
            a.enabled = enableTrail;
        }
    }

    public void ToggleSlowMo()
    {
        enableSlowMo = !enableSlowMo;
    }

    public void ToggleAudio()
    {
        enableAudio = !enableAudio;
        foreach (var a in FindObjectsOfType<AudioSource>())
        {
            a.enabled = enableAudio;
        }
    }

    private void Awake()
    {
        Instance = this;
        ToggleTrail();
        ToggleAudio();
        ToggleSlowMo();
    }

    private void Start()
    {
        isGameRunning = true;
        pauseMenu.SetActive(false);
        ChangeColor(0);
        
    }

    public void ChangeColor(int i)
    {
        Debug.Log("Change color");
        
        backgroundColor = palette.backgroundColors[i];
        squareColor = palette.squareColors[i];
        circleColor = palette.circleColors[i];
        clickColor = palette.clickColors[i];

        foreach (var obj in FindObjectsOfType<ExplosiveObject>())
        {
            obj.SetColor(obj.isCircle ? circleColor : squareColor);
        }

        background.material.color = backgroundColor;
        background.material.SetColor("_RingColor", clickColor);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (isGameRunning)
            {
                isGameRunning = false;
                pauseMenu.SetActive(false);
                pauseMenu.SetActive(true);
            }
            else
            {
                isGameRunning = true;
                pauseMenu.SetActive(true);
                pauseMenu.SetActive(false);
            }
        }
    }
}
