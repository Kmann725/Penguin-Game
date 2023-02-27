/*
 * Gerard Lamoureux, Kyle Manning
 * PlayerController
 * Team Project 1
 * Handles Overall Player
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour, IPlayerSubject
{
    public float walkingSpeed = 5f;
    public float slidingSpeed = 10f;
    public float maxSlidingSpeed = 20f;
    public float jump = 5f;
    public float mouseSensitivity = 5f;
    private bool isJumping = false;
    private float xRot;
    private float xMovement;
    private float zMovement;

    private Vector3 spawnPoint;

    private Rigidbody rb;

    public int FishCollected = 0;

    private bool isTeleporting = false;

    public static PlayerController ThisPlayerController;

    public AudioClip call;
    public AudioClip sliding;
    public AudioClip walking;
    public AudioClip eating;

    private bool moveSoundPlaying = false;

    public AudioSource[] sources;

    List<IPlayerObserver> observers = new List<IPlayerObserver>();

    private PlayerData playerDataForObservers = new PlayerData();

    private ISlideable slideable = new NotSliding();

    #region Grounded
    public Transform groundCheck;
    public float groundDistance = 0.2f;
    public LayerMask groundMask;
    private bool grounded = true;
    #endregion

    void Awake()
    {
        ThisPlayerController = this;

        sources = GetComponents<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;

        spawnPoint = transform.position;
    }

    public void SetSlideMode(ISlideable slideable)
    {
        this.slideable = slideable;
    }

    public bool IsPlayerSliding()
    {
        return slideable.IsPlayerSliding;
    }

    // Update is called once per frame
    void Update()
    {
        xMovement = Input.GetAxis("Horizontal");
        zMovement = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(grounded)
                isJumping = true;
        }
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (slideable.IsPlayerSliding)
            {
                SetSlideMode(new NotSliding());
                sources[1].clip = walking;
                moveSoundPlaying = false;
            }
            else
            {
                SetSlideMode(new IsSliding());
                sources[1].clip = sliding;
                moveSoundPlaying = false;
            }
                
            NotifyPlayerObservers();
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            sources[0].PlayOneShot(call);
        }

        if ((xMovement != 0 || zMovement != 0) && !moveSoundPlaying && grounded)
        {
            sources[1].Play();
            moveSoundPlaying = true;
        }
        else if (((rb.velocity.x <= 0.05f && rb.velocity.x >= -0.05f) && (rb.velocity.z <= 0.05f && rb.velocity.z >= -0.05f) && moveSoundPlaying) || !grounded)
        {
            sources[1].Stop();
            moveSoundPlaying = false;
        }

        /*
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (x != 0 && grounded)
        {
            rb.AddForce(transform.right * (x * speed * Time.deltaTime), ForceMode.Impulse);
        }

        if (z != 0 && grounded)
        {
            rb.AddForce(transform.forward * (z * speed * Time.deltaTime), ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.AddForce(Vector3.up * jump);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }*/
    }

    void FixedUpdate()
    {
        grounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        (isJumping) = slideable.slide(rb, grounded, walkingSpeed, slidingSpeed, maxSlidingSpeed, jump, isJumping, xMovement, zMovement);
    }

    /// <summary>
    /// Grounded handled with physics instead of collisions.
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        /*if (collision.gameObject.CompareTag("ground"))
        {
            grounded = true;
        }*/
    }

    private void OnCollisionExit(Collision collision)
    {
        /*if (collision.gameObject.CompareTag("ground"))
        {
            grounded = false;
        }*/
    }

    public void RegisterPlayerObserver(IPlayerObserver observer)
    {
        observers.Add(observer);
        NotifyPlayerObservers();
    }

    public void RemovePlayerObserver(IPlayerObserver observer)
    {
        if (observers.Contains(observer))
            observers.Remove(observer);
    }

    public void NotifyPlayerObservers()
    {
        UpdatePlayerDataForObservers();
        foreach (IPlayerObserver observer in observers)
            observer.UpdateData(playerDataForObservers);
        isTeleporting = false;
    }

    public void UpdatePlayerDataForObservers()
    {
        playerDataForObservers.FishCollected = FishCollected;
        playerDataForObservers.IsPlayerSliding = IsPlayerSliding();
        playerDataForObservers.IsPlayerTeleporting = isTeleporting;
    }

    public void TeleportToSpawn()
    {
        isTeleporting = true;
        transform.position = spawnPoint;
        NotifyPlayerObservers();
    }
}
