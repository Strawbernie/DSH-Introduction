using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;
using UnityEngine.XR;

public class XRSettingsManager : MonoBehaviour
{
    public static event Action XRSettingsChange;
    public static XRSettingsManager Instance;
    private InputDevice RightController;
    public GameObject leftController;
    public GameObject rightController;
    public InputData inputData;
    public bool _continuousTurnActive = false;
    public bool _vignetteActive = false;
    public bool _teleportActive = false;
    float distance;
    private void Start()
    {
        RightController = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
    }
    private void Update()
    {
        CheckControllerInput(RightController);
    }
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void setContinuousTurn(int dropdownSetting)
    {
        if(dropdownSetting == 0)
        {
            _continuousTurnActive = false;
        }
        else
        {
            _continuousTurnActive = true;
        }
        XRSettingsChange?.Invoke();
    }

    public void setVignette(bool vignetteValue)
    {
        _vignetteActive = vignetteValue;
        XRSettingsChange?.Invoke();
    }
    public void setTeleport(bool teleportValue)
    {
        _teleportActive = teleportValue;
        XRSettingsChange?.Invoke();
    }
    public bool isContinuousTurnActive()
    {
        return _continuousTurnActive;
    }
    public bool isVignetteActive()
    {
        return _vignetteActive;
    }
    public bool isTeleportActive()
    {
        return _teleportActive;
    }
    private void CheckControllerInput(InputDevice controller)
    {
        if (inputData._rightController.TryGetFeatureValue(CommonUsages.primaryButton, out bool AButton))
        {
            if (AButton)
            {
               distance = Vector3.Distance (rightController.transform.position, leftController.transform.position);
                Debug.Log("" + distance);
            }
        }
    }
}
