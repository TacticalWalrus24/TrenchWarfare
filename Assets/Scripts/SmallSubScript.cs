using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallSubScript : MonoBehaviour
{
    public GameObject projectile;
    public Transform gunLeft;
    public Transform gunRight;
    public float firerate = 0.75f;
    public float hp = 100;

    public GameObject player;
    private bool canShoot = true;

    private void FixedUpdate()
    {
        if (player != null)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, transform.position.y - player.transform.position.y, transform.position.z - player.transform.position.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        int rNum = Random.Range(0, 25);

        if (rNum == 0 && canShoot)
        {
            StartCoroutine("Shoot");
        }
        if (transform.position.x >= 30 || hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            hp -= collision.gameObject.GetComponent<WeaponScript>().damage;
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;

//        Instantiate(projectile, gunLeft.position, gunLeft.rotation);
//        Instantiate(projectile, gunRight.position, gunRight.rotation);

        yield return new WaitForSeconds(firerate);

        canShoot = true;
    }
}
