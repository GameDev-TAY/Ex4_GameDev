using UnityEngine;

/**
 * This component moves its object in a fixed velocity.
 * NOTE: velocity is defined as speed+direction.
 *       speed is a number; velocity is a vector.
 */
public class Mover: MonoBehaviour {
    [Tooltip("Movement vector in meters per second")][SerializeField] Vector3 velocity;
    [Tooltip("Extra space from the camera bounds for distroy enemy point")] [SerializeField] float extra = 5f;
    private Vector2 screenBounds; 

    private void Start()
    {
        //Get the Screen boundes from the main camera.
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    } 

    void Update() {
        //The movement of Objects - set velosity.
        transform.position += velocity * Time.deltaTime;

        //distroy element that get out of the boundes.
        Vector3 pos = transform.position;
        if (pos.x >= screenBounds.x + extra ||
            pos.x <= -screenBounds.x - extra ||
            pos.y >= screenBounds.y + extra ||
            pos.y <= -screenBounds.y - extra)
        {
            Destroy(gameObject);
        }
    }

    //set new velosity to the element.
    public void SetVelocity(Vector3 newVelocity) {
        this.velocity = newVelocity;
    }
}
