using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AIRacing : MonoBehaviour
{
    public float movementSpeed;
    float initialVelocity = 0f;
    float finalVelocity = .8f;
    float currentVelocity = 0f;
    float accelerationRate = .02f;
    float decelerationRate = .2f;
    float rotationSpeed = 2f;
    public bool braking;
    public int maxCheckPoints;
    public GameObject[] checkPoints;
    public GameObject target;
    GameObject previousTarget;
    public int currentTarget=0;
    public float brakeTime;
    bool crashed;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Checkpoint")
        {
            previousTarget = other.gameObject;
            currentTarget++;
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
