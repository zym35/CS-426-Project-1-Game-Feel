using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public bool isGameRunning;
    public GameObject pauseMenu;
    public PaletteScriptableObject palette;
    public Color backgroundColor, squareColor, circleColor, clickColor;

    private void Start()
    {
        isGameRunning = true;
        ChangeColor(0);
    }

    public void ChangeColor(int i)
    {
        backgroundColor = palette.backgroundColors[i];
        squareColor = palette.squareColors[i];
        circleColor = palette.circleColors[i];
        clickColor = palette.clickColors[i];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGameRunning)
            {
                isGameRunning = false;
                Time.timeScale = 0;
                pauseMenu.SetActive(false);
            }
            else
            {
                isGameRunning = true;
                Time.timeScale = 1;
                pauseMenu.SetActive(true);
            }
        }
    }
}
