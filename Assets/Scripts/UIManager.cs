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

    private void Awake()
    {
        Instance = this;
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGameRunning)
            {
                isGameRunning = false;
                Time.timeScale = 0;
                pauseMenu.SetActive(false);
                pauseMenu.SetActive(true);
            }
            else
            {
                isGameRunning = true;
                Time.timeScale = 1;
                pauseMenu.SetActive(true);
                pauseMenu.SetActive(false);
            }
        }
    }
}
