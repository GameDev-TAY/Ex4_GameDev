using UnityEngine;

/**
 * This component moves its object in a fixed velocity.
 * NOTE: velocity is defined as speed+direction.
 *       speed is a number; velocity is a vector.
 */
public class Mover: MonoBehaviour {
    [Tooltip("Movement vector in meters per second")]
    [SerializeField] Vector3 velocity;
    private Vector2 screenBounds;
    [SerializeField] float extra = 5f;

    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    } 

    void Update() {
        transform.position += velocity * Time.deltaTime;
        Vector3 pos = transform.position;
        if (pos.x >= screenBounds.x + extra ||
            pos.x <= -screenBounds.x - extra ||
            pos.y >= screenBounds.y + extra ||
            pos.y <= -screenBounds.y - extra)
        {
            Destroy(gameObject);
        }
    }

    public void SetVelocity(Vector3 newVelocity) {
        this.velocity = newVelocity;
    }
}
