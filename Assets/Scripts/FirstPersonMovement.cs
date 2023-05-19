using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 5;
    public float speedIncrease = 5;
    public bool speedPowerUp = false;
    public float speedCooldown = 5;

    public GameObject speedIndicator;
    public GameObject ItIndicator;

    public AudioClip shieldpowerupSound;
    public AudioClip speedpowerupSound;
    public AudioClip shieldPowerupSound;
    public AudioClip speedPowerupSound;
    private AudioSource source;

    private float xRightBound = 19;
    private float xLeftBound = -18.12f;
    private float zBottomBound = -18.89f;
    private float zTopBound = 18.235f;

    [Header("Running")]
    public bool canRun = true;
    public bool IsRunning { get; private set; }
    public float runSpeed = 9;
    public KeyCode runningKey = KeyCode.LeftShift;
    

    Rigidbody rigidbody;
    /// <summary> Functions to override movement speed. Will use the last added override. </summary>
    public List<System.Func<float>> speedOverrides = new List<System.Func<float>>();

    private void Start()
    {
        speedIndicator.gameObject.SetActive(false);
        ItIndicator.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (GameManager.GetGameManager().isGameOver) 
            return;

        //TagManager.GetTagManager().GetWhoIsIt();
        //making YOU ARE IT ui element show up when tagged
        if (TagManager.GetTagManager().GetWhoIsIt().CompareTag("Player"))
        {
            ItIndicator.gameObject.SetActive(true);
        }
        else//and disappear when untagged
        {
            ItIndicator.gameObject.SetActive(false);
        }

        //don't fall off
        if(transform.position.x > xRightBound)
        {
            transform.position = new Vector3(xRightBound, transform.position.y, transform.position.z);
        }

        if (transform.position.x < xLeftBound)
        {
            transform.position = new Vector3(xLeftBound, transform.position.y, transform.position.z);
        }

        if (transform.position.z < zBottomBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBottomBound);
        }

        if (transform.position.z > zTopBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zTopBound);
        }
    }
    //speedPowerUp goes brrr
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup") && speedPowerUp == false)
        {
            speedPowerUp = true;
            Destroy(other.gameObject);
            speed += speedIncrease;
            speedIndicator.gameObject.SetActive(true);
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
        speedIndicator.gameObject.SetActive(false);
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
