using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SliceCubeUpDown : MonoBehaviour
{
    public GameObject target;
    public float moveSpeed;
    SpawnManager spawnManager;
    public TMP_Text text;
    bool goingup = false;

    private void Start()
    {
        target = GameObject.FindWithTag("Server");
        spawnManager = FindObjectOfType<SpawnManager>();
        text = FindObjectOfType<TMP_Text>();
    }
    void Update()
    {
        if (target != null)
        {
            Vector3 direction = (target.transform.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
            gameObject.transform.LookAt(target.transform.position);
        }
        float moveAmount = moveSpeed* Time.deltaTime;
        Vector3 currentX= transform.position;
        if (!goingup)
        {
            currentX.y -= moveAmount;
        }
        else
        {
            currentX.y += moveAmount;
        }
        if (currentX.y < 1)
        {
            goingup= true;
        }
        else if (currentX.y>2)
        {
            goingup= false;
        }
        gameObject.transform.localPosition = currentX;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DamageZone"))
        {
            spawnManager.HP--;
            text.text = ("HP:" + spawnManager.HP);
            spawnManager.CheckHP();
            Destroy(gameObject);
        }
    }
}
