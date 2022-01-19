using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Trigger : MonoBehaviour
{
    public SpawnManager shoot;
    private AudioSource girlAudio;
    public AudioClip[] girlSound;
    // Start is called before the first frame update
    void Start()
    {
        girlAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        int index = Random.Range(0, girlSound.Length);
        shoot.Shoot();
        girlAudio.PlayOneShot(girlSound[index]);
        Debug.Log("Shoot");
    }
   
    
}
