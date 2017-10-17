using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class LevelMannger
{
    //通过的关卡
    public  List<GameObject> beClear = new List<GameObject>(50);

    //难度因素 
    //转速
    public static float rotateSpeed = 50;
    //发射速度
    public static float shootSpeed = 5;


    //关卡进行到哪里？
    public static int levelNumber = 1;

}
public class TitleScene : MonoBehaviour {

    public List<GameObject> levelButton;
    int levelNumber;
     public LevelMannger lm;

    //难度系数
    private int difficultCoefficient;
    // Use this for initialization
    void Start () {

        LevelMannger.levelNumber = PlayerPrefs.GetInt("levelnumber");
        if (PlayerPrefs.GetInt("levelnumber") == 0)
        {
            LevelMannger.levelNumber = 1;
        }
        lm = new LevelMannger();
        levelNumber = LevelMannger.levelNumber;
        for (int i = 0;i<levelButton.Count;i++)
        {
            levelButton[i].GetComponent<Button>().onClick.AddListener(GoToGame);
            levelButton[i].GetComponentInChildren<Text>().text = (i + 1).ToString();
            if (i < levelNumber)
            {
                levelButton[i].transform.GetChild(1).GetComponent<Image>().enabled = false;
                lm.beClear.Add(levelButton[i]);
            }
        }

        
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void GoToGame()
    {
        if (lm.beClear.Contains(EventSystem.current.currentSelectedGameObject))
        {
            LevelMannger.levelNumber = levelButton.IndexOf(EventSystem.current.currentSelectedGameObject) + 1;
            SceneManager.LoadScene(1);
        }
        else
        {
            print("请通关前一关！~");
        }

    }
    public void Quit()
    {
        
        Application.Quit();

    }


}
