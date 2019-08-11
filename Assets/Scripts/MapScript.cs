using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScript : MonoBehaviour
{
    public float speed = 100;
    public Transform player;
    public GameObject walls;
    public GameObject rotationPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movement();
    }

    void movement()
    {
        transform.position += new Vector3((speed * Time.deltaTime), 0, 0); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<GameObject>().CompareTag("Player"))
        {
            if (player.position.z < -29)
            {
                rotationPoint.transform.position = player.position;
                walls.transform.SetParent(rotationPoint.transform);
                rotationPoint.transform.Rotate(0, 30, 0);
            }
            else
            {

            }
        }
    }
}
