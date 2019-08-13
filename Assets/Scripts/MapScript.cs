using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScript : MonoBehaviour
{
    public float speed = 100;
    public Transform player;
    public GameObject walls;
    public GameObject rotationPoint;

    bool hasTurned = false;
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
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(speed, 0, 0); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasTurned)
        {
            if (player.position.z < -29)
            {
                rotationPoint.transform.position = player.position;
                walls.transform.SetParent(rotationPoint.transform);
                rotationPoint.transform.Rotate(0, 30, 0);
                hasTurned = true;
            }
            else
            {

            }
        }
    }
}
