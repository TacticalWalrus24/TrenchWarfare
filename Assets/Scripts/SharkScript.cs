using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SharkScript : MonoBehaviour
{
    public GameObject tail;
    public GameObject projectile;
    public GameObject marker;
    public Transform gun;
    public Transform markerPoint;
    public float speed = 25;
    public float firerate = 0.75f;
    public float tailRot = 0.5f;
    public float hp = 100;

    public GameObject player;
    private GameObject spawnTo;
    private Quaternion startRot;
    private bool canShoot = true;
    private bool isMarked = false;
    // Start is called before the first frame update
    void Start()
    {
        startRot = tail.transform.rotation;
    }

    private void FixedUpdate()
    {
        if (player != null)
        {
            

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Quaternion v = startRot;
            v.y += tailRot * (Mathf.Sin(Time.time * speed) - 0.005f);
            tail.transform.rotation = v;

            int rNum = Random.Range(0, 25);

            if (rNum == 0 && canShoot)
            {
                StartCoroutine("Shoot");
            }
            if (transform.position.x >= 30 || hp <= 0){
                Destroy(gameObject);
            }
            if (transform.position.z >= player.transform.position.z - 5 && transform.position.z <= player.transform.position.z + 5
                && transform.position.y >= player.transform.position.y - 5 && transform.position.y <= player.transform.position.y + 5)
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

        Instantiate(projectile, gun.position, gun.rotation);

        yield return new WaitForSeconds(firerate);

        canShoot = true;
    }
}
