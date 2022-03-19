using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public GameManager gameManager;
    private float horizontalInput;
    private float verticalInput;
    public bool isPowerUp;
    public float speed;
    

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        

        isPowerUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.isGameOver)
        {
            Vector3 MousePos = Input.mousePosition;
            transform.position = gameManager.mainCam.ScreenToWorldPoint(MousePos + new Vector3(0, 130, 130));
            if (transform.position.z > 165)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, 165);
            }

        }
        
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            isPowerUp = true;
            gameObject.transform.localScale = new Vector3(5, 5, 5);
            Debug.Log("Powerup");
            StartCoroutine(PowerUpCountDown());
        }
    }
    IEnumerator PowerUpCountDown()
    {
        yield return new WaitForSeconds(15);
        isPowerUp = false;
        gameObject.transform.localScale = new Vector3(2, 2, 2);
        
    }
    
}
