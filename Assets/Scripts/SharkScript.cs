using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkScript : MonoBehaviour
{
    public GameObject player;
    public GameObject tail;
    public GameObject projectile;
    public Transform gun;
    public float speed = 25;
    public float firerate = 0.75f;
    public float tailRot = 0.5f;
    public float hp = 100;

    private Quaternion startRot;
    private bool canShoot = true;
    // Start is called before the first frame update
    void Start()
    {
        startRot = tail.transform.rotation;
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(-speed * Time.deltaTime * 50, transform.position.y - player.transform.position.y, transform.position.z - player.transform.position.z) * -0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion v = startRot;
        v.y += tailRot * (Mathf.Sin(Time.time * speed) - 0.005f);
        tail.transform.rotation = v;

        int rNum = Random.Range(0, 25);

        if (rNum == 0)
        {
            StartCoroutine("Shoot");
        }
        if (transform.position.x >= 30){
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

        Instantiate(projectile, gun.position, gun.rotation);

        yield return new WaitForSeconds(firerate);

        canShoot = true;
    }
}
