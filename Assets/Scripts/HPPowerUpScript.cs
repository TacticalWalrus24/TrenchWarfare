using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPPowerUpScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.instance.playerHealth += 200;
        Destroy(gameObject);
    }
}
