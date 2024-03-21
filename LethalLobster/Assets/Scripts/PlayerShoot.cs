using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab; // Drag your bullet prefab here

    [SerializeField]
    private Transform gunPosition; // Drag your gun position transform here

    [SerializeField]
    private float bulletSpeed = 10f; // Set your desired bullet speed

    private InputActions controls; // Assuming PlayerControls is the generated C# class for your Input Actions

    private void Awake()
    {
        controls = new InputActions();

    }

    private void Shoot(InputAction.CallbackContext input)
    {
        GameObject bullet = Instantiate(bulletPrefab, gunPosition.position, Quaternion.identity);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

        if (bulletRb != null)
        {
            int rnd = Random.Range(1, 4);
            SoundManager.Instance.Play("Pop_" + rnd);
            // Use the forward direction of the gun transform
            Vector3 shootDirection = gunPosition.forward;

            bulletRb.velocity = shootDirection * bulletSpeed;
        }
    }

    private void OnEnable()
    {
        controls.Enable();
        controls.Player.Fire.performed += Shoot;

    }

    private void OnDisable()
    {
        controls.Disable();
        controls.Player.Fire.performed -= Shoot;
    }
}
