using UnityEngine;
using System.Collections;

public class LootWeapon : LootBase
{

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other);
        if (other.tag == "Player")
        {
            other.GetComponent<Hero>().UpgradeWeapon();
            Destroy(gameObject);
        }
    }
}
