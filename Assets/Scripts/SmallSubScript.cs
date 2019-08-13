using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallSubScript : MonoBehaviour
{
    public GameObject projectile;
    public GameObject marker;
    public Transform gunLeft;
    public Transform gunRight;
    public Transform markerPoint;
    public float firerate = 0.75f;
    public float hp = 100;
    public int value = 0;

    public GameObject player;
    private GameObject spawnTo;
    private bool canShoot = true;
    private bool isMarked = false;

    private void FixedUpdate()
    {
        if (player != null)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, transform.position.y - (player.transform.position.y - 0.5f), transform.position.z - player.transform.position.z) * -1;
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
        if (transform.position.z >= player.transform.position.z - 2 && transform.position.z <= player.transform.position.z + 2
                && transform.position.y >= player.transform.position.y - 2 && transform.position.y <= player.transform.position.y + 2)
        {
            if (!isMarked)
            {
                spawnTo = Instantiate(marker, markerPoint);

                spawnTo.transform.parent = transform;
                isMarked = true;
            }
        }
        else if (isMarked)
        {
            Destroy(spawnTo);
            isMarked = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            hp -= collision.gameObject.GetComponent<WeaponScript>().damage;
            GameManager.instance.score += value;
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.playerHealth -= 400;
            Destroy(gameObject);
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
