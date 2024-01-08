using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class GameManager : MonoBehaviour
{
  public TextMeshProUGUI scoreText;
  public TextMeshProUGUI bestText;
  public GameObject HideText;
  public TextMeshProUGUI GameOverScoreText;
  public TextMeshProUGUI GameOverHighScoreText;
  [SerializeField] GameObject GameOverPanel;
  public int Score;
  public int bestScore;
  public Button exitbutton;
  public AudioClip[] sliceSound;
  private AudioSource audiosource;

  private void Awake()
  {
    Advertisement.Initialize("5516031");
    audiosource=GetComponent<AudioSource>();
    GameOverPanel.SetActive(false);
  }
  private void Start()
  {
    bestText.text = "Best: " + getScore().ToString();
  }
  public void IncreaseScore(int points)
  {
    Score += points;
    scoreText.text = "Score: " + Score.ToString();
    if (Score > getScore())
    {
      PlayerPrefs.SetInt("HighScore", Score);
      bestText.text = "Best: " + getScore().ToString();
    }
    
  }

  public int getScore()
  {
      int best = PlayerPrefs.GetInt("HighScore",0);
      return best;
    
  }
  public void GetBombHit()
  {
    AudioClip BombBlast = sliceSound[2];
    foreach (GameObject g in GameObject.FindGameObjectsWithTag("Foul"))
    {
      audiosource.PlayOneShot(BombBlast);
    }
    Advertisement.Show("Interstitial_Android");
    Time.timeScale = 0;
    Debug.Log("Bomb Hitted!!");
    GameOverPanel.SetActive(true);
    HideText.SetActive(false);
    exitbutton.interactable = false;
    GameOverHighScoreText.text = "HIGHSCORE: " +getScore().ToString();
    GameOverScoreText.text="SCORE: " + Score.ToString();
  }
  public void RestartGame()
  {
    Score = 0;
    HideText.SetActive(true);
    exitbutton.interactable = true;
    scoreText.text = "Score: 0";
    GameOverHighScoreText.text = "HIGHSCORE: " + getScore().ToString();
    GameOverScoreText.text = "SCORE: " + Score.ToString();
    GameOverPanel.SetActive(false);
    foreach (GameObject g in GameObject.FindGameObjectsWithTag("Interactable"))
    {
      Destroy(g);
      foreach (GameObject f in GameObject.FindGameObjectsWithTag("Foul"))
      {
        Destroy(f);
      }
    }
    
    Time.timeScale = 1;
  }

  public void GetRandomSliceSound()
  {
    AudioClip randomSounds = sliceSound[Random.Range(0, 1)];
    audiosource.PlayOneShot(randomSounds);
    
  }
  public void FinishGame()
  {
    Application.Quit();
    Debug.Log("Quited!!");
  }
}
