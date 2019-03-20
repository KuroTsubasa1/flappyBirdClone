using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    private Vector3 newPosition = new Vector3(0f, 5f, 0f);
    private float timeStamp = 0;
    private int coolDownPeriodInSeconds = 0;
    public static Vector3 playerPos;


    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = newPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
        moveForward();

            checkInput();
    }

    void moveForward()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x + 0.1f, gameObject.transform.position.y, gameObject.transform.position.z);
        playerPos = gameObject.transform.position;
    }

    void checkInput()
    {   
        if(Input.GetKeyDown((KeyCode.Space)) && timeStamp <= Time.time)
        {
            rb.velocity = new Vector3(0, 0, 0);
            rb.AddForce(new Vector3(0f, 1000f, 0f), ForceMode.Impulse);
            timeStamp = Time.time + coolDownPeriodInSeconds;
        }
    }

}

