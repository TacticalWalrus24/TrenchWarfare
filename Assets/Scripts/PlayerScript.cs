using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("Player Movement")]
    public GameObject playerBody;
    public float speed = 25;
    public float rollAmount = 15;
    public float maxHeight, minHeight;

    [Header("Guns")]
    public Transform gunLeft;
    public Transform gunRight;
    public GameObject projectile;
    public float firerate = 0.25f;

    private bool canShoot = true;

    // Update is called once per frame
    void FixedUpdate()
    {
        float verti = Input.GetAxis("Vertical");
        float hori = Input.GetAxis("Horizontal");

        if (verti > 0 || verti < 0)
        {
            Movement(verti, 'y');
        }

        if (hori > 0 || hori < 0)
        {
            Movement(hori, 'z');
        }

        if (Input.GetKey(KeyCode.Space) && canShoot)
        {
            StartCoroutine("Shoot");
        }
    }

    void Movement(float scale, char axis)
    {
        if (axis == 'y')
        {
            playerBody.GetComponent<Rigidbody>().velocity = new Vector3(0, (speed * scale), playerBody.GetComponent<Rigidbody>().velocity.z);
        }
        else
        {
            playerBody.GetComponent<Rigidbody>().velocity = new Vector3(0, playerBody.GetComponent<Rigidbody>().velocity.y, (speed * scale));
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;

        Instantiate(projectile, gunLeft.position, gunLeft.rotation);
        Instantiate(projectile, gunRight.position, gunRight.rotation);

        yield return new WaitForSeconds(firerate);

        canShoot = true;
    }
}