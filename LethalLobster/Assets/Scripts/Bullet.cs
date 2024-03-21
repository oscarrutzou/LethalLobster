using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float maxTravelDistance = 100f; // Set your desired max travel distance

    [SerializeField]
    private int damage = 10; // Set your desired damage

    [SerializeField]
    private GameObject bubbleParticles;

    private Vector3 startPosition;



    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        // Check if the bullet has traveled the max distance
        if (Vector3.Distance(startPosition, transform.position) >= maxTravelDistance)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the object the bullet hit has an AIHealth script
        AIHealth aiHealth = collision.gameObject.GetComponent<AIHealth>();
        
        if (aiHealth != null)
        {
            // Call the Damage function on the AIHealth script
            aiHealth.Damage(damage);
        }
        SoundManager.Instance.Play("Bubbles");

        Instantiate(bubbleParticles, transform.position, Quaternion.identity);
        Debug.Log(transform.position);
        //ParticleSystem bullet = Instantiate(bulletPrefab, gunPosition.position, Quaternion.identity);
        //Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

         // Use the forward direction of the gun transform
        //Vector3 shootDirection = gunPosition.forward;
        // Destroy the bullet
        Destroy(gameObject);
    }
}
