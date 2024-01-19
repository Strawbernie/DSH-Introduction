using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostPickup : MonoBehaviour
{
    public float boostDuration = 1f; // Adjust the duration of the speed boost
    public float boostMultiplier = 1.01f; // Adjust the speed boost multiplier

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Assuming your player has the "Player" tag
        {
            ApplySpeedBoost(other.gameObject);
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
