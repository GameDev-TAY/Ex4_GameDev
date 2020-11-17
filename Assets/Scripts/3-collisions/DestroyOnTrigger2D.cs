using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This component destroys its object whenever it triggers a 2D collider with the given tag.
 */
public class DestroyOnTrigger2D : MonoBehaviour {
    [Tooltip("Every object tagged with this tag will trigger the destruction of this object and the other object")][SerializeField] string triggeringTag;
    [Tooltip("Every object tagged with this tag will trigger just the destruction of the other object")] [SerializeField] string triggeringByTag;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == triggeringTag && enabled) {
            if (this.gameObject.tag == "Player") this.gameObject.GetComponent<HealthSystem>().Damage(); //for player
            else Destroy(this.gameObject);// for laser
            Destroy(other.gameObject);
        }
        if (other.tag == triggeringByTag && enabled) //for the big laser that not destroy on trigger.
        {
            Destroy(this.gameObject);
        }
    }
}
