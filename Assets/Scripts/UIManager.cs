using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public List<GameObject> lstGoUIs = new();
    public int currentIndexUI;
    public TestPhysics testPhysic;
    public SpawnManager spawnManager;
    public TextMeshProUGUI txtScore_MainMenu;
    public TextMeshProUGUI txtScore_Gameplay;
    public TextMeshProUGUI txtScore_GameOver;
    public TextMeshProUGUI txtScore_Result;
    public TextMeshProUGUI txtBestScore_Result;
    public List<GameObject> lstGoLives = new();
    public Animator animatorFade;

    private int indexUI;
    public GameObject goFade;

    // Start is called before the first frame update
    void Start()
    {
        currentIndexUI = 0;
        ShowAnimationFade(0);
        SetScore(0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowUI(int index)
    {
        lstGoUIs[currentIndexUI].SetActive(false);
        currentIndexUI = index;
        lstGoUIs[currentIndexUI].SetActive(true);
    }

    public void ShowGameplay()
    {
        ShowUI(1);
        testPhysic.gameObject.SetActive(true);
        testPhysic.StartGame();
        spawnManager.isStartGame = true;
    }

    public void ShowGameOver()
    {
        ShowUI(2);
        testPhysic.gameObject.SetActive(false);
    }

    public void ShowMainMenu()
    {
        ShowUI(0);
        testPhysic.gameObject.SetActive(false);
        spawnManager.isStartGame = false;
    }

    public void SetScore(int score)
    {
        int bestScore = PlayerPrefs.GetInt("BestScore", 0);
        txtScore_MainMenu.text = bestScore.ToString();
        txtScore_Gameplay.text = score.ToString();
        txtScore_GameOver.text = score.ToString();

        txtScore_Result.text = score.ToString();

        if (bestScore < score)
        {
            bestScore = score;
            PlayerPrefs.SetInt("BestScore", bestScore);
        }

        txtBestScore_Result.text = bestScore.ToString();
    }

    public void SetLives(int lives)
    {
        for (int i = 0; i < lstGoLives.Count; i++)
        {
            if (i < lives)
            {
                lstGoLives[i].SetActive(true);
            }
            else
            {
                lstGoLives[i].SetActive(false);
            }
        }
    }

    public void ShowUIAfterFade()
    {
        //goFade.SetActive(false);
        switch (indexUI)
        {
            case 0:
                ShowMainMenu(); break;
            case 1:
                ShowGameplay(); break;
            default:
                ShowGameOver(); break;
        }
    }

    public void ShowAnimationFade(int index)
    {
        indexUI = index;
        goFade.SetActive(false);
        goFade.SetActive(true);
    }
}
