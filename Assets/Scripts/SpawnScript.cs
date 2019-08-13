using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject enemyOne;
    public GameObject enemyTwo;
    public GameObject enemyThree;
    public GameObject player;

    public float spawnRate = 100;

    bool canSpawn = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int rand = Random.Range(0, 10);

        if (rand == 0 && canSpawn)
        {
            StartCoroutine("Spawn");
        }
    }

    IEnumerator Spawn()
    {
        canSpawn = false;

        int rand = Random.Range(0, 2);
        int randY = Random.Range(-15, 15);
        int randZ = Random.Range(-15, 15);


        switch (rand)
        {
            case (0):
                if (player != null)
                {
                    enemyOne.GetComponent<SharkScript>().player = player;
                }
                Instantiate(enemyOne, new Vector3(transform.position.x, randY, randZ), transform.rotation);
                break;
            case (1):
                if (player != null)
                {
                    enemyTwo.GetComponent<SmallSubScript>().player = player;
                }
                Instantiate(enemyTwo, new Vector3(transform.position.x, randY, randZ), transform.rotation);
                break;
            case (2):
                Instantiate(enemyThree, new Vector3(transform.position.x, randY, randZ), transform.rotation);
                break;
            default:
                break;
        }

        yield return new WaitForSecondsRealtime(spawnRate);

        canSpawn = true;
    }
}
