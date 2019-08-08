using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public float speed = 1000;
    public float damage = 100;
    public bool explosive = false;
    public bool penetrative = false;
    public GameObject explosion = null;
    public GameObject propeller = null;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("DeathTimer");
        GetComponent<Rigidbody>().AddForce(new Vector3(-speed, 0, 0));
    }

    private void Update()
    {
        if (propeller != null)
        {
            propeller.transform.Rotate(new Vector3((50 * Time.deltaTime), 0, 0));
        }
    }

    IEnumerator DeathTimer()
    {
        yield return new WaitForSeconds(5f);

        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            if (explosive)
            {
                Instantiate(explosion);
            }
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            if (explosive)
            {
                Instantiate(explosion);
            }
            Destroy(gameObject);
        }
    }
}
