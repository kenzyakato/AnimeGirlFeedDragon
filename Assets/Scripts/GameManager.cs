using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Animator enemyAni;
    public bool isGameOver;
    public Counter counter;
    public TextMeshProUGUI gameOverText;
    public PlayerController player;
    private SpawnManager spawnManager;
    
    public Camera mainCam;
    public Camera overCam;
    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        StartGame();
        
    }
    public void GameOver()
    {
        isGameOver = true;
        mainCam.gameObject.SetActive(false);
        overCam.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        Debug.Log("GameOver");
        enemyAni.speed = 1;
        enemyAni.SetBool("isGameOver",isGameOver);
    }
    public void StartGame()
    {
        
        //游戏开始 初始化条件
        spawnManager.wave = 1;
        mainCam.gameObject.SetActive(true);
        overCam.gameObject.SetActive(false);
        player.gameObject.transform.localScale = new Vector3(2, 2, 2);
        counter.Count = 0;
        counter.CounterText.text = "Point : 0";
        isGameOver = false;
        enemyAni.SetBool("isGameOver", isGameOver);
        gameOverText.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        //ゲーム終了 Rボタンでリスタート
        if (isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                StartGame();
            }
        }
    }
    
}
