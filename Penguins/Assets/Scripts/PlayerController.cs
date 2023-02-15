using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour, IPlayerSubject
{
    public float speed = 5f;
    public float jump = 5f;
    public float mouseSensitivity = 5f;
    private bool canJump = true;
    private bool grounded = true;
    private float xRot;

    private Rigidbody rb;

    public int FishCollected = 0;

    public static PlayerController ThisPlayerController;

    List<IPlayerObserver> observers = new List<IPlayerObserver>();

    void Awake()
    {
        ThisPlayerController = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (x != 0 && grounded && rb.)
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
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            canJump = true;
            grounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            canJump = false;
            grounded = false;
        }
    }

    public void RegisterPlayerObserver(IPlayerObserver observer)
    {
        observers.Add(observer);
        observer.UpdateData(this);
    }

    public void RemovePlayerObserver(IPlayerObserver observer)
    {
        if (observers.Contains(observer))
            observers.Remove(observer);
    }

    public void NotifyPlayerObservers()
    {
        foreach (IPlayerObserver observer in observers)
            observer.UpdateData(this);
    }
}
