using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR;
using TMPro;
using UnityEngine.SceneManagement;

public class Racing : MonoBehaviour
{
  public float movementSpeed;
    private InputDevice RightController;
    private InputDevice LeftController;
    public InputData inputData;
    float initialVelocity = 0f;
    float finalVelocity = .8f;
    float currentVelocity = 0f;
    float accelerationRate = .02f;
    float decelerationRate = .05f;
    bool checkpoint1 = false;
    bool checkpoint2 = false;
    bool checkpoint3 = false;
    bool checkpoint4 = false;
    int lap = 0;
    bool crashed;
    bool accelerating;
    public GameObject previousTarget;
    public TextMeshProUGUI text;
    public TextMeshProUGUI result;
    float yRot;
    public bool lost;
    bool wantsReset;
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
        text.text = ("Lap"+(lap+1)+"/3");
        if (!crashed && gameObject.transform.position.y < -.5f||wantsReset)
        {
            wantsReset = false;
            crashed = true;
            currentVelocity = 0f;
            gameObject.transform.position = new Vector3(previousTarget.transform.position.x, 1, previousTarget.transform.position.z);
            gameObject.transform.rotation = new Quaternion(0, yRot, 0,0);
            StartCoroutine(StopBraking());
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
                currentVelocity = currentVelocity + (accelerationRate * Time.deltaTime);
                transform.Translate(0, 0, currentVelocity);
            }
        }
        if (inputData._rightController.TryGetFeatureValue(CommonUsages.triggerButton, out bool RightButton))
        {
            if (RightButton)
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
        }
    }
}
