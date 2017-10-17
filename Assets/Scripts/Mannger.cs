﻿ using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Mannger : MonoBehaviour {
    public static int needleNumber;
    public Text needleNumberText;
    public static Mannger instance;
    public GameObject needle;
    public static bool isGameOver;
    public Text time;
    public GameObject restartWindow;
    public GameObject winWindow;
    private float speed;
    private void Awake()
    {
        winWindow.SetActive(false);
        instance = this;
    }
    // Use this for initialization
    void Start () {
        print("当前关卡" + LevelMannger.levelNumber);
        isGameOver = false;
        speed = 0.37f * LevelMannger.levelNumber + 4.63f;

        winWindow.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
        needleNumberText.text = needleNumber.ToString();

        if (Input.GetMouseButtonDown(0))
        {
            NeedleBehaviour.speed =speed;
        }

        if (isGameOver)
        {
            restartWindow.SetActive(true);
            time.text = Time.timeSinceLevelLoad.ToString("0.0");
        }
        else
        {
            restartWindow.SetActive(false);
        }

        if (needleNumber >=2)
        {
            winWindow.SetActive(true);
        }
	}
    public void NewNeedle()
    {
        needleNumberText.GetComponent<Animator>().Play("StitchOnAnimation");
        Instantiate(needle);
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
        needleNumber = 0;
    }

    public void toMain()
    {
        //
        //lm.beClear.Add(ts.levelButton[LevelMannger.levelNumber + 1])

        LevelMannger.levelNumber++;

        SceneManager.LoadScene(1);
    }
}
