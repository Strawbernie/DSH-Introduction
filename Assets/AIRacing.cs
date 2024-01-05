using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AIRacing : MonoBehaviour
{
    public float movementSpeed;
    float initialVelocity = 0f;
    float finalVelocity = 1f;
    float currentVelocity = 0f;
    float accelerationRate = .01f;
    float decelerationRate = .05f;
    float rotationSpeed = 1.5f;
    public GameObject[] checkPoints;
    public GameObject target;
    public int currentTarget=0;
    void Start()
    {
        checkPoints = GameObject.FindGameObjectsWithTag("Checkpoint");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Checkpoint")
        {
            currentTarget++;
        }
    }
    // Update is called once per frame
    void Update()
    {
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
        Accelerate();
    }
    public void Accelerate()
    {
        currentVelocity = currentVelocity + (accelerationRate * Time.deltaTime);
        transform.Translate(0, 0, currentVelocity);
    }
    public void Brake()
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
