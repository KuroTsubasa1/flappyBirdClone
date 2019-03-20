using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FloorController : MonoBehaviour
{
  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

       // Debug.Log(GameManager.newPosition.x);

        if (gameObject.transform.position.x < PlayerController.playerPos.x - 20)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.rigidbody.tag == "Player")
        {
            SceneManager.LoadScene(1);
        }
        

    }
}
