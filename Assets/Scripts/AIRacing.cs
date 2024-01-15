using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AIRacing : MonoBehaviour
{
    public float movementSpeed;
    float initialVelocity = 0f;
    float finalVelocity = .5f;
    float currentVelocity = 0f;
    float accelerationRate = .02f;
    float decelerationRate = .2f;
    float rotationSpeed = 2.5f;
    public bool braking;
    public int maxCheckPoints;
    public GameObject[] checkPoints;
    public GameObject target;
    public GameObject previousTarget;
    public int currentTarget=0;
    public float brakeTime;
    bool crashed;
    bool checkpoint1 = false;
    bool checkpoint2 = false;
    bool checkpoint3 = false;
    bool checkpoint4 = false;
    float yRot;
    int lap = 0;
    Racing player;
    private void Start()
    {
        player = FindObjectOfType<Racing>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Checkpoint")
        {
            if(other.gameObject == target)
            {
                previousTarget = other.gameObject;
                yRot = gameObject.transform.rotation.y;
                currentTarget++;
            }
        }
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
                checkpoint1 = false;
                checkpoint2 = false;
                checkpoint3 = false;
                checkpoint4 = false;
            }
            if (lap >= 3)
            {
                player.lost = true;
                Debug.Log("W");
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!crashed && gameObject.transform.position.y < .5f)
        {
            crashed = true;
            braking = true;
            currentVelocity= 0f;
            brakeTime = 1;
            gameObject.transform.position = new Vector3(previousTarget.transform.position.x, 1, previousTarget.transform.position.z);
            gameObject.transform.rotation = new Quaternion(0, yRot, 0, 0);
            StartCoroutine(StopBraking());
        }
        if (currentTarget >= maxCheckPoints)
        {
            currentTarget = 0;
        }
        if (target != null)
        {
            Vector3 direction = (target.transform.position - transform.position).normalized;
            currentVelocity = Mathf.Clamp(currentVelocity, initialVelocity, finalVelocity);
        }
        target = checkPoints[currentTarget];
        Vector3 dir = target.transform.position - transform.position;
        dir.y = 0;
        Quaternion rot = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, rotationSpeed * Time.deltaTime);
        if (braking)
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
        else
        {
            Accelerate();
        }
    }
    public void Accelerate()
    {
            currentVelocity = currentVelocity + (accelerationRate * Time.deltaTime);
            transform.Translate(0, 0, currentVelocity);
    }
    public void Brake()
    {
        if (currentVelocity > .2f)
        {
            braking = true;
            StartCoroutine(StopBraking());
        }
    }
    IEnumerator StopBraking()
    {
        yield return new WaitForSeconds(brakeTime);
        braking= false;
        if (crashed)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, gameObject.transform.rotation.y, gameObject.transform.rotation.z);
            crashed = false;
        }
    }
}
