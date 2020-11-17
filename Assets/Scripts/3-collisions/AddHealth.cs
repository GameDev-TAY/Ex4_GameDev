using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHealth : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") // verify that the collider is the player
        {
            Debug.Log("Health triggered by player");
            var HealthComponent = other.GetComponent<HealthSystem>(); //get the health system of the player.
            if (HealthComponent.lives < 3)
            {
                //add live scale the player up and destroy the health object.
                HealthComponent.lives++;
                other.transform.localScale /= 0.8f;
                Destroy(gameObject);
            }
        }
    }
}
