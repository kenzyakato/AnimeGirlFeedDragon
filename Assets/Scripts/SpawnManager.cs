﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SpawnManager : MonoBehaviour
{
    public TextMeshProUGUI waveCount;
    public int wave = 1;
    private float waveSpeed = 2.5f;
    public float gravity;
    public GameObject[] targets;
    public GameObject powerUp;
    //public List<GameObject> pooledObjects;
    private int targetsIndex;
    public GameManager gameManager;
    private int n = 0;
    // Start is called before the first frame update
    void Start()
    {
        //环境初始化和调用协程函数

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Physics.gravity *= gravity;
        StartCoroutine(Timer());
        //StartCoroutine(SpawnTargets(0));

    }

    // Update is called once per frame
    void Update()
    {
        waveCount.text = "WAVE:" + wave;
    }
    IEnumerator Timer()
    {//根据wave数加快小球生成
        Debug.Log("Wave: " + wave);
        yield return new WaitForSeconds(30);
        if (!gameManager.isGameOver)
        {

            wave++;
            waveSpeed /= wave;
            gameManager.enemyAni.speed *= wave;
            
            if (wave > 2)
            {
                StartCoroutine(SpawnTargets(0));
            }
        }
        else
        {
            wave = 1;
        }
        StartCoroutine(Timer());
    }
    IEnumerator SpawnTargets(int n)
    {
        //小球生成间隔
        yield return new WaitForSeconds(waveSpeed);
        if (!gameManager.isGameOver)
        {
            //每十五个小球生成一个powerup
            n++;
            if (n > 15)
            {
                Instantiate(powerUp, this.transform);
                n = 0;
            }
            else
            {
                targetsIndex = Random.Range(0, targets.Length);
                Instantiate(targets[targetsIndex], this.transform);
            }
        }
        if (wave > 2) { StartCoroutine(SpawnTargets(n)); }
        

        /*GameObject pooledProjectile = GetPooledObject();
        if (pooledProjectile != null)
        {
            pooledProjectile.SetActive(true); // activate it
            pooledProjectile.transform.position = transform.position; // position it at SpawnManager
        }*/
    }
    /*public GameObject GetPooledObject()
    {
        // For as many objects as are in the pooledObjects list
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            // if the pooled objects is NOT active, return that object 
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        // otherwise, return null   
        return null;
    }*/
    public void Shoot()
    {
        
        if (!gameManager.isGameOver)
        {
            //每十五个小球生成一个powerup
            n++;
            if (n > 15)
            {
                Instantiate(powerUp, this.transform);
                n = 0;
            }
            else
            {
                targetsIndex = Random.Range(0, targets.Length);
                Instantiate(targets[targetsIndex], this.transform);
            }
        }
    }
}
