using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SliceCubeHeal : MonoBehaviour
{
    public GameObject target;
    public float moveSpeed;
    SpawnManager spawnManager;
    public TMP_Text text;

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
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Server"))
        {
            spawnManager.HP++;
            text.text = ("HP:" + spawnManager.HP);
            Destroy(gameObject);
        }
    }
}
