using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCommands : MonoBehaviour
{
    public bool shouldBrake;
    public float brakeTime;
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "AICar")
        {
            if (shouldBrake)
            {
                AIRacing AIracing =other.GetComponent<AIRacing>();
                AIracing.brakeTime=brakeTime;
                AIracing.Brake();
            }
        }
    }
}
