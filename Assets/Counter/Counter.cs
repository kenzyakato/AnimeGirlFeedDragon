using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Counter : MonoBehaviour
{
    public TextMeshProUGUI CounterText;
    public GameManager gameManager;
    private AudioSource playerAudio;
    public AudioClip mogumogu;
    public int Count = 0;

    private void Start()
    {
        Count = 0;
        playerAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Mogumogu();
        Destroy(other.gameObject);
        Count += 1;
        CounterText.text = "Point : " + Count;
    }
    public void Mogumogu()
    {
        playerAudio.PlayOneShot(mogumogu);
    }
}
