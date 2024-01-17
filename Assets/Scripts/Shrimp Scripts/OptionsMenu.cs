using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class OptionsMenu : MonoBehaviour
{
    private XRSettingsManager settingsManager;
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;
    public TMP_Dropdown turnDropdown;
    public Toggle vignetteToggle;
    public Toggle teleportationToggle;
    //UI for Quiz
    public GameObject CalcArms;
    public GameObject Picked;
    public GameObject Confirm;
    public GameObject Experience;
    public GameObject Movement;
    public GameObject Sickness;
    public GameObject Often;
    private InputDevice RightController;
    public GameObject leftController;
    public GameObject rightController;
    public InputData inputData;
    float distance;
    private void Start()
    {
        RightController = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
    }
    private void Update()
    {
        CheckControllerInput(RightController);
    }
    private void CheckControllerInput(InputDevice controller)
    {
        if (inputData._rightController.TryGetFeatureValue(CommonUsages.primaryButton, out bool AButton))
        {
            if (AButton)
            {
                distance = Vector3.Distance(rightController.transform.position, leftController.transform.position);
                Debug.Log("" + distance);
                if (distance > 1.2f)
                {
                    ScoreManager.armLength = distance;
                    Experience.SetActive(true);
                    CalcArms.SetActive(false);
                }
            }
        }
    }
    private void Awake()
    {
        settingsManager = FindObjectOfType<XRSettingsManager>();
        masterSlider.onValueChanged.AddListener(MasterVolumeChange);
        musicSlider.onValueChanged.AddListener(MusicVolumeChange);
        sfxSlider.onValueChanged.AddListener(SFXVolumeChange);

        turnDropdown.onValueChanged.AddListener(TurnChange);
        vignetteToggle.onValueChanged.AddListener(VignetteChange);
        teleportationToggle.onValueChanged.AddListener(teleportChange);
        CheckSettings();
    }

    private void OnDestroy()
    {
        masterSlider.onValueChanged.RemoveListener(MasterVolumeChange);
        musicSlider.onValueChanged.RemoveListener(MusicVolumeChange);
        sfxSlider.onValueChanged.RemoveListener(SFXVolumeChange);

        turnDropdown.onValueChanged.AddListener(TurnChange);
    }
    private void MasterVolumeChange(float volume)
    {
        SoundManager.Instance.SetMasterVolume(volume);
    }
    private void MusicVolumeChange(float volume)
    {
        SoundManager.Instance.SetMusicVolume(volume);
    }
    private void SFXVolumeChange(float volume)
    {
        SoundManager.Instance.SetSFXVolume(volume);
    }
    private void TurnChange(int dropdownValue)
    {
        XRSettingsManager.Instance.setContinuousTurn(dropdownValue);
    }
    private void VignetteChange(bool vignetteValue)
    {
        XRSettingsManager.Instance.setVignette(vignetteValue);
    }
    private void teleportChange(bool teleportValue)
    {
        XRSettingsManager.Instance.setTeleport(teleportValue);
    }
    public void ExperienceYes()
    {
        Movement.SetActive(true);
        Experience.SetActive(false);
    }
    public void ExperienceNo()
    {
        Sickness.SetActive(true);
        Experience.SetActive(false);
        teleportationToggle.isOn = true;
    }
    public void MovementYes()
    {
        Sickness.SetActive(true);
        Movement.SetActive(false);
        teleportationToggle.isOn = false;
    }
    public void MovementReturn()
    {
        Movement.SetActive(false);
        Experience.SetActive(true);
    }
    public void MovementNo()
    {
        Sickness.SetActive(true);
        Movement.SetActive(false);
        teleportationToggle.isOn = true;
    }
    public void SicknessYes()
    {
        Often.SetActive(true);
        Sickness.SetActive(false);
        //Snap Turn
        turnDropdown.value = 0;
    }
    public void SicknessReturn()
    {
        Sickness.SetActive(false);
        Movement.SetActive(true);
    }
    public void SicknessNo()
    {
        Picked.SetActive(true);
        Confirm.SetActive(true);
        Sickness.SetActive(false);
        //Continuous Turn
        turnDropdown.value = 1;
    }
    public void OftenYes()
    {
        Picked.SetActive(true);
        Confirm.SetActive(true);
        Often.SetActive(false);
        vignetteToggle.isOn = true;
    }
    public void OftenReturn()
    {
        Often.SetActive(false);
        Sickness.SetActive(true);
    }
    public void OftenNo()
    {
        Picked.SetActive(true);
        Confirm.SetActive(true);
        Often.SetActive(false);
        vignetteToggle.isOn = false;
    }
    public void CheckSettings()
    {
        if (settingsManager._continuousTurnActive)
        {
            turnDropdown.value = 1;
        }
        else
        {
            turnDropdown.value = 0;
        }
        if (settingsManager._vignetteActive)
        {
            vignetteToggle.isOn = true;
        }
        else
        {
            vignetteToggle.isOn = false;
        }
        if (settingsManager._teleportActive)
        {
            teleportationToggle.isOn = true;
        }
        else
        {
            teleportationToggle.isOn = false;
        }
    }
}
