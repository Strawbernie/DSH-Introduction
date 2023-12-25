using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBehavior : MonoBehaviour
{
    GameObject target;
    public float moveSpeed;
    bool stopMoving = false;

    private void Start()
    {
        target = GameObject.FindWithTag("DamageZone");
    }
    void Update()
    {
        if (target != null && !stopMoving)
            {
                Vector3 direction = (target.transform.position - transform.position).normalized;
                transform.position += direction * moveSpeed * Time.deltaTime;
            }
        }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DamageZone"))
        {
            stopMoving= true;
        }
    }
}
