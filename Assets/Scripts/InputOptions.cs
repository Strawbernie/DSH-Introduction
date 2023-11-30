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
            //Makes the menu visible if it was not
            if (!isActive && !pressedButton && LeftButton)
            {
                isActive = true;
                Menu.SetActive(true);
                pressedButton = true;
            }
            //Makes the menu invisible if it was not
            else if (isActive && !pressedButton && LeftButton)
            {
                isActive = false;
                Menu.SetActive(false);
                pressedButton = true;
            }
        }
        if (!LeftButton)
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