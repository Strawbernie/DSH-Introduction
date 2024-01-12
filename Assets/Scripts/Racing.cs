using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR;

public class Racing : MonoBehaviour
{
  public float movementSpeed;
    private InputDevice RightController;
    private InputDevice LeftController;
    public InputData inputData;
    float initialVelocity = 0f;
    float finalVelocity = 1f;
    float currentVelocity = 0f;
    float accelerationRate = .01f;
    float decelerationRate = .05f;
    bool checkpoint1 = false;
    bool checkpoint2 = false;
    bool checkpoint3 = false;
    bool checkpoint4 = false;
    int lap = 0;
    void Start()
    {
        RightController = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
    }

    // Update is called once per frame
    void Update()
    {
        CheckControllerInput(RightController);
        CheckControllerInput(LeftController);
        currentVelocity = Mathf.Clamp(currentVelocity, initialVelocity, finalVelocity);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "PlayerCheckpoint")
        {
            PlayerCheckpoint PC = other.GetComponent<PlayerCheckpoint>();
            switch (PC.ID) 
            { 
                case 0:
                    checkpoint1 = true;
                    break;
                case 1:
                    checkpoint2 = true;
                    break;
                case 2:
                    checkpoint3 = true;
                    break;
                case 3:
                    checkpoint4 = true;
                    break;
            }
        }
        if (other.transform.tag == "Finish")
        {
            if (checkpoint1 && checkpoint2 && checkpoint3 && checkpoint4) 
            {
                lap++;
                checkpoint1= false;
                checkpoint2 = false;
                checkpoint3 = false;
                checkpoint4 = false;
            }
            if(lap>=3)
            {
                Debug.Log("W");
            }
        }
    }
    private void CheckControllerInput(InputDevice controller)
    {
        if (inputData._leftController.TryGetFeatureValue(CommonUsages.triggerButton, out bool LeftButton))
        {
            if (LeftButton)
            {
                currentVelocity = currentVelocity + (accelerationRate * Time.deltaTime);
                transform.Translate(0, 0, currentVelocity);
            }
        }
        else
        {
            currentVelocity = currentVelocity - (decelerationRate * Time.deltaTime);
            if (currentVelocity > 0)
            {
                transform.Translate(0, 0, currentVelocity);
            }
            else
            {
                transform.Translate(0, 0, 0);
            }
        }
        if (inputData._rightController.TryGetFeatureValue(CommonUsages.triggerButton, out bool RightButton))
        {
            if (RightButton)
            {
               
            }
        }
    }
}
