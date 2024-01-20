using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostPickup : MonoBehaviour
{
    public float boostDuration = 1f; 
    public float boostMultiplier = 2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            ApplySpeedBoost(other.gameObject);
            Debug.Log("applied");
        }
    }

    void ApplySpeedBoost(GameObject player)
    {
        Racing carController = player.GetComponent<Racing>();

        if (carController != null)
        {
            carController.ApplySpeedBoost(boostDuration, boostMultiplier);
        }
    }
}
