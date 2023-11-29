using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class XRSettingsManager : MonoBehaviour
{
    public static event Action XRSettingsChange;
    public static XRSettingsManager Instance;

    public bool _continuousTurnActive = false;
    public bool _vignetteActive = false;
    public bool _teleportActive = false;
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
}
