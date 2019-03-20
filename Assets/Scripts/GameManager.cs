using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject grass;
    public GameObject tube;

    private bool firstFrame = true;

    public static Vector3 newPosition = new Vector3(0f, 0f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        newPosition = new Vector3(this.gameObject.transform.position.x, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(firstFrame)
        {

            firstFrame = false;
        }

    }

    void spawnGrass()
    {
        Instantiate(grass, newPosition, Quaternion.identity);
        newPosition = new Vector3(newPosition.x + 2, 0, 0);
    }

    void spawnTube()
    {
        Instantiate(tube, new Vector3(newPosition.x, -3  + Random.Range(0,-3), newPosition.z), Quaternion.identity);
    }

    void spawnTubeDown()
    {
        var pipe = Instantiate(tube, new Vector3(newPosition.x, 24 - Random.Range(0,3), newPosition.z), Quaternion.identity);
        pipe.transform.rotation = Quaternion.Euler(0, 0, -180);
    }

    void generateNewChunk()
    {
        bool lastHasTube = false;
        int lastTubePositionX = 0;
        for (int i = 0; i < 20; i++)
        {
            if(lastTubePositionX + 2 == newPosition.x)
            {
                lastHasTube = false;
            }

            spawnGrass();
            if(Random.Range(0,5) == 1 )
            {
                spawnTube();
                lastHasTube = true;

            }

            if (Random.Range(0, 5) == 1)
            {
                spawnTubeDown();
            }

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            generateNewChunk();

            gameObject.transform.position = new Vector3(gameObject.transform.position.x + 20f, 0, 0);
        }
    }
}

