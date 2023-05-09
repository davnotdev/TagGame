using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 5;
    public float speedIncrease = 5;
    public bool speedPowerUp = false;
    public float speedCooldown = 5;
    public AudioClip shieldPowerupSound;
    public AudioClip speedPowerupSound;
    private AudioSource source;

    [Header("Running")]
    public bool canRun = true;
    public bool IsRunning { get; private set; }
    public float runSpeed = 9;
    public KeyCode runningKey = KeyCode.LeftShift;
    

    Rigidbody rigidbody;
    /// <summary> Functions to override movement speed. Will use the last added override. </summary>
    public List<System.Func<float>> speedOverrides = new List<System.Func<float>>();

    private void Update()
    {
            
    }
    //speedPowerUp goes brrr
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            speedPowerUp = true;
            Destroy(other.gameObject);
            speed += speedIncrease;
            StartCoroutine(SpeedPowerUpCountdownRoutine());
            source.PlayOneShot(speedPowerupSound);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Shield"))
        {
            source.PlayOneShot(shieldPowerupSound);
        }
    }

    IEnumerator SpeedPowerUpCountdownRoutine()
    {
        yield return new WaitForSeconds(speedCooldown);
        speed -= speedIncrease;
        speedPowerUp = false;
    }

    void Awake()
    {
        // Get the rigidbody on this.
        rigidbody = GetComponent<Rigidbody>();
        source = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        // Update IsRunning from input.
        IsRunning = canRun && Input.GetKey(runningKey);

        // Get targetMovingSpeed.
        float targetMovingSpeed = IsRunning ? runSpeed : speed;
        if (speedOverrides.Count > 0)
        {
            targetMovingSpeed = speedOverrides[speedOverrides.Count - 1]();
        }

        // Get targetVelocity from input.
        Vector2 targetVelocity =new Vector2( Input.GetAxis("Horizontal") * targetMovingSpeed, Input.GetAxis("Vertical") * targetMovingSpeed);

        // Apply movement.
        rigidbody.velocity = transform.rotation * new Vector3(targetVelocity.x, rigidbody.velocity.y, targetVelocity.y);
    }
}