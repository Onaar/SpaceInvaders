using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArea : MonoBehaviour
{
    AlienFleetController alienFleetController;

    private void Start()
    {
        alienFleetController = GameObject.FindGameObjectWithTag("alienFleet").GetComponent<AlienFleetController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Alien")
        {
            alienFleetController.StopGame(false);
        }
    }
}
