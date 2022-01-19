using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    public GameManager gameManager;
    private float pushForce;
    public float maxForceRange = 50;
    public float minForeceRange = 20;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        targetRb = GetComponent<Rigidbody>();
        pushForce = Random.Range(minForeceRange, maxForceRange);
        float forceX = Random.Range(-0.5f, 0.5f);
        targetRb.AddForce((Vector3.up*0.5f+Vector3.back*0.5f+Vector3.right*forceX) * pushForce, ForceMode.Impulse);
        targetRb.AddTorque(pushForce, pushForce, pushForce);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            
            Destroy(gameObject);
            if (!gameObject.CompareTag("PowerUp"))
            {
                gameManager.GameOver();
            }
        }
        
    }
}
