using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class InputOptions : MonoBehaviour
{
    private InputDevice LeftController;
    private InputDevice RightController;
    public InputData inputData;
    bool isActive;
    public GameObject Menu;
    public GameObject controlMenu;
    bool pressedButton;
    bool BisActive;
        bool BPressedButton;
    private void Start()
    {
        LeftController = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        RightController = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
    }
    private void Update()
    {
        CheckControllerInput(LeftController);
        CheckControllerInput(RightController);
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
        if (inputData._rightController.TryGetFeatureValue(CommonUsages.secondaryButton, out bool BButton))
        {
            //Makes the menu visible if it was not
            if (!BisActive && !BPressedButton && BButton)
            {
                BisActive = true;
                if (controlMenu != null)
                {
                    controlMenu.SetActive(true);
                }
                BPressedButton = true;
            }
            //Makes the menu invisible if it was not
            else if (BisActive && !BPressedButton && BButton)
            {
                BisActive = false;
                if (controlMenu != null)
                {
                    controlMenu.SetActive(false);
                }
                BPressedButton = true;
            }
        }
        if (!BButton)
        {
            BPressedButton = false;
        }
    }
    public void MenuConfirmed()
    {
        isActive = false;
        Menu.SetActive(false);
    }
}