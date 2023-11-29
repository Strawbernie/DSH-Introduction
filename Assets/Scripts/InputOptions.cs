using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class InputOptions : MonoBehaviour
{
    private InputDevice LeftController;
    public InputData inputData;
    bool isActive;
    public GameObject Menu;
    bool pressedButton;
    private void Start()
    {
        LeftController = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
    }
    private void Update()
    {
        CheckControllerInput(LeftController);
    }
    private void CheckControllerInput(InputDevice controller)
    {
        if (inputData._leftController.TryGetFeatureValue(CommonUsages.menuButton, out bool LeftButton))
        {
            
            if (!isActive && LeftButton && !pressedButton)
            {
                isActive = true;
                Menu.SetActive(true);
                pressedButton = true;
            }
        }
        else
        {
            pressedButton = false;
        }
    }
    public void MenuConfirmed()
    {
        isActive = false;
        Menu.SetActive(false);
    }
}