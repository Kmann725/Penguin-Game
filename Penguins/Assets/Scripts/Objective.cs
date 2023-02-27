using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Objective : MonoBehaviour
{
    public TextMeshPro textbox;

    private GameObject player;

    private bool began = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = player.transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!began)
        {
            textbox.text = "This is a test";
        }
        else
        {
            textbox.gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        began = true;

        textbox.gameObject.GetComponent<MeshRenderer>().enabled = false;
    }
}
