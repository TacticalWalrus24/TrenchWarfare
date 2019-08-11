using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject enemyOne;
    public GameObject enemyTwo;
    public GameObject enemyThree;
    public Transform spawnPoint;
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

        spawnPoint.position.Set(spawnPoint.position.x, randY, randZ);


        switch (rand)
        {
            case (0):
                enemyOne.GetComponent<SharkScript>().player = player;
                Instantiate(enemyOne, spawnPoint);
                break;
            case (1):
                Instantiate(enemyTwo, spawnPoint);
                enemyOne.GetComponent<SmallSubScript>().player = player;
                break;
            case (2):
                Instantiate(enemyThree, spawnPoint);
                break;
            default:
                break;
        }

        spawnPoint.position.Set(0, 0, 0);

        yield return new WaitForSecondsRealtime(spawnRate);

        canSpawn = true;
    }
}
