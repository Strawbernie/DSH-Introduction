using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SliceCubeMovement : MonoBehaviour
{
    public GameObject target;
    public float moveSpeed;
    SpawnManager spawnManager;
    ComboManager comboManager;
    public TMP_Text text;

    private void Start()
    {
        target = GameObject.FindWithTag("Server");
        spawnManager = FindObjectOfType<SpawnManager>();
        comboManager = FindObjectOfType<ComboManager>();
        text = FindObjectOfType<TMP_Text>();
    }
    void Update()
    {
        if (target != null)
        {
            Vector3 direction = (target.transform.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DamageZone"))
        {
            spawnManager.HP--;
            ScoreManager.Missed++;
            Debug.Log("missed:"+ScoreManager.Missed);
            comboManager.UpdateCombo();
            spawnManager.CheckHP();
            Destroy(gameObject);
        }
    }
}
