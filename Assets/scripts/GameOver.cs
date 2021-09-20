using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    public GameObject Gameover;
    public TextMeshProUGUI secondsSurvivedUI;
    public TextMeshProUGUI totScore;
    public TextMeshProUGUI close_calls;
    bool gameover = false;
    public GameObject scoreScreen;
    int startTime = 0;
    public AudioSource backSong;
    public AudioSource deathSound;
    public Player player;
    //public event System.Action showAD;
    //public AdManager AdManager;




    void Start()
    {
        player.OnPlayerDeath += gameOver;
    }
    void gameOver()
    {
        scoreScreen.SetActive(false);
        Gameover.SetActive(true);
        totScore.text = ((int)player.Score + (int)Time.timeSinceLevelLoad).ToString();
        secondsSurvivedUI.text = "seconds survived: "+((int)Time.timeSinceLevelLoad).ToString();
        close_calls.text = "close calls: "+(player.close_call_store).ToString();
        gameover = true;
        backSong.Stop();
        deathSound.Play();
       
    }
    public void Retry()
    {
        gameover = false;
        SceneManager.LoadScene(1);
    }
}
