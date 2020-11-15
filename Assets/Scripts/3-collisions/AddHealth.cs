using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHealth : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Cannon triggered by player");
            var HealthComponent = other.GetComponent<HealthSystem>();
            if (HealthComponent.lives < 3)
            {
                HealthComponent.lives++;
                other.transform.localScale /= 0.8f;
                Destroy(gameObject);
            }
        }
    }
}
