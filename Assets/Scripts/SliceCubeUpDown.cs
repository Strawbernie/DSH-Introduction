using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SliceCubeUpDown : MonoBehaviour
{
    public float moveSpeed;
    SpawnManager spawnManager;
    public TMP_Text text;
    bool goingup = false;

    private void Start()
    {
        spawnManager = FindObjectOfType<SpawnManager>();
        text = FindObjectOfType<TMP_Text>();
    }
    void Update()
    {
        float moveAmount = moveSpeed* Time.deltaTime;
        Vector3 currentX= transform.position;
        currentX.x -= moveAmount;
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
            Destroy(gameObject);
        }
    }
}
