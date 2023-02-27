using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Objective : MonoBehaviour
{
    public TextMeshPro textbox;
    public TextMeshProUGUI timer;

    public PlayerController pc;
    public GameObject winScreen;
    public GameObject loseScreen;

    private GameObject player;

    private bool began = false;
    private bool nearNest = false;
    private bool trigger = false;

    public int minutes = 6;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = player.transform.rotation;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (pc.FishCollected >= 25 && nearNest)
            {
                winScreen.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                textbox.text = "Our chick needs food. About 25 fish should do before we switch. Return here once you've collected them.";
                if (!began)
                {
                    trigger = true;
                }
            }
        }

        if (pc.FishCollected >= 30)
        {
            textbox.text = "Press E";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        nearNest = true;

        textbox.gameObject.GetComponent<MeshRenderer>().enabled = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!began && nearNest && trigger)
        {
            StartCoroutine(Timer());
            began = true;
            trigger = false;
        }

        if (began)
        {
            textbox.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }

        nearNest = false;
    }

    IEnumerator Timer()
    {
        timer.enabled = true;

        var seconds = 60;
        minutes--;

        while (minutes >= 0 && seconds > -1)
        {
            if (seconds == 0)
            {
                minutes--;
                seconds = 59;
            }
            else
            {
                seconds--;
            }

            if (seconds < 10)
            {
                timer.text = minutes + ":0" + seconds;
            }
            else
            {
                timer.text = minutes + ":" + seconds;
            }

            yield return new WaitForSeconds(1f);

            if (minutes == 0 && seconds == 0)
            {
                seconds = -1;
            }
        }

        loseScreen.SetActive(true);
        Time.timeScale = 0;
    }
}
