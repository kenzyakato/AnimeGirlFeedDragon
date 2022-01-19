using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeClothOff : MonoBehaviour
{
    private SpawnManager spawnManager;
    public SkinnedMeshRenderer cloth1;
    public SkinnedMeshRenderer cloth2;
    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        cloth1 = GameObject.Find("Anon_Dress").GetComponent<SkinnedMeshRenderer>();
        cloth2 = GameObject.Find("Anon_Hudie").GetComponent<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnManager.wave == 1)
        {
            cloth1.enabled = true;
            cloth2.enabled = true;
        }
        if (spawnManager.wave == 2)
        {
            cloth2.enabled = false;
            
        }else if(spawnManager.wave == 3)
            {
            cloth1.enabled = false;
        }

    }
}
