using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SliceCubeHeal : MonoBehaviour
{
    public float moveSpeed;
    SpawnManager spawnManager;
    public TMP_Text text;

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
        gameObject.transform.localPosition = currentX;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DamageZone"))
        {
            spawnManager.HP++;
            text.text = ("HP:" + spawnManager.HP);
            Destroy(gameObject);
        }
    }
}
