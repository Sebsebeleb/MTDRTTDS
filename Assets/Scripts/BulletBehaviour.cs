using System.Security.Cryptography;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BulletBehaviour : MonoBehaviour
{

    public GameObject Target;
    public float Speed = 5f; // Movement speed of the bullet
    public bool IsHoming = true; // Should the bullet change course?
    public float Damage; // Damage dealt to enemies on contact
    private Vector3 movementDirection; // Used when non-homing and homing that is not 100% tracking

    private void Update()
    {
        if (!Target) {
            Destroy(gameObject);
        }

        // Find the direction to move
        if (IsHoming) {
            movementDirection = (Target.transform.position - transform.position).normalized;
            iTween.LookTo(gameObject, Target.transform.position, 0f);
        }

        Vector3 vel = movementDirection*Speed*Time.deltaTime;
        transform.Translate(vel);
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        GameObject other = col.gameObject;

        other.BroadcastMessage("TakeHit", Damage);
        Destroy(gameObject);
    }
}
