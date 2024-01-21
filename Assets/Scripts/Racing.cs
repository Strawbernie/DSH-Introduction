using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;

public class Racing : MonoBehaviour
{
    private InputDevice RightController;
    private InputDevice LeftController;
    public InputData inputData;
     float acceleration = 140f; 
   float brakeForce = 36f;
    bool checkpoint1 = false;
    bool checkpoint2 = false;
    bool checkpoint3 = false;
    bool checkpoint4 = false;
    private Rigidbody rb;
    int lap = 0;
    bool crashed;
    bool accelerating;
    public GameObject previousTarget;
    public TextMeshProUGUI text;
    public TextMeshProUGUI result;
    float yRot;
    public bool lost;
    bool wantsReset;
    private bool isSpeedBoosted = false;
    float boostStartTime;
    float boostDuration;
    public TextMeshProUGUI countdownText;
    public float totalTime = 5f;
    public bool started;
    void Start()
    {
        RightController = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        rb = GetComponent<Rigidbody>();
        UpdateTimerDisplay();
        InvokeRepeating("UpdateTimer", 1f, 1f);
    }
    void UpdateTimer()
    {
        totalTime -= 1f;
        UpdateTimerDisplay();

        if (totalTime <= 0f)
        {
            started = true;
            countdownText.gameObject.SetActive(false);
            CancelInvoke("UpdateTimer");
        }
    }

    void UpdateTimerDisplay()
    {
        countdownText.text = "" + totalTime;
    }

    void Update()
    {
        if (started)
        {
            CheckControllerInput(RightController);
            CheckControllerInput(LeftController);
            text.text = ("Lap" + (lap + 1) + "/3");
            if (!crashed && gameObject.transform.position.y < -.5f || wantsReset)
            {
                wantsReset = false;
                crashed = true;
                gameObject.transform.position = new Vector3(previousTarget.transform.position.x, 1, previousTarget.transform.position.z);
                gameObject.transform.rotation = new Quaternion(0, yRot, 0, 0);
                StartCoroutine(StopBraking());
            }
            if (isSpeedBoosted)
            {
                if (Time.time - boostStartTime > boostDuration)
                {
                    isSpeedBoosted = false;
                    acceleration = 140f;
                }
            }
        }
    }
    public void ApplySpeedBoost(float duration, float multiplier)
    {
        if (!isSpeedBoosted)
        {
            isSpeedBoosted = true;
            boostDuration = duration;
            boostStartTime = Time.time;
            acceleration *= multiplier;
        }
    }
    IEnumerator StopBraking()
    {
        yield return new WaitForSeconds(1);
        if (crashed)
        {
            crashed = false;
        }
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
        if (other.transform.tag == "Checkpoint")
        {
            previousTarget = other.gameObject;
            yRot= gameObject.transform.rotation.y;
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
                if (lost)
                {
                    ScoreManager.wonRacing = false;
                    result.text = "You Lost!";
                    Invoke("LoadEndScreen", 3f);
                }
                else
                {
                    ScoreManager.wonRacing = true;
                    result.text = "You Win!";
                    Invoke("LoadEndScreen", 3f);
                }
            }
        }
    }
    void LoadEndScreen()
    {
        SceneManager.LoadScene("RacingEndScreen");
    }
    private void CheckControllerInput(InputDevice controller)
    {
        if (inputData._rightController.TryGetFeatureValue(CommonUsages.primaryButton, out bool YButton))
        {
            if (YButton)
            {
                wantsReset= true;
            }
        }
                if (inputData._leftController.TryGetFeatureValue(CommonUsages.triggerButton, out bool LeftButton))
        {
            if (LeftButton)
            {
                Accelerate();
            }
        }
        else if (inputData._rightController.TryGetFeatureValue(CommonUsages.triggerButton, out bool RightButton))
        {
            if (RightButton)
            {
                Brake();
            }
        }
        else
        {
            ApplyNaturalDeceleration();
        }
    }
    void Accelerate()
    {
        float speed = rb.velocity.magnitude;
            rb.AddForce(transform.forward * acceleration);
    }

    void Brake()
    {
        // Apply braking force
        rb.AddForce(-transform.forward * brakeForce);
    }

    void ApplyNaturalDeceleration()
    {
        // Apply a small deceleration force to simulate friction
        rb.velocity *= 0.995f;
    }
}
