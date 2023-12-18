using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SliceCubeUpDown : MonoBehaviour
{
    public GameObject target;
    public float moveSpeed;
    public float verticalSpeed;
    ComboManager comboManager;
    SpawnManager spawnManager;
    public TMP_Text text;
    bool goingup = false;

    private void Start()
    {
        target = GameObject.FindWithTag("Server");
        spawnManager = FindObjectOfType<SpawnManager>();
        text = FindObjectOfType<TMP_Text>();
        comboManager = FindObjectOfType<ComboManager>();
    }
    void Update()
    {
        if (target != null)
        {
            Vector3 direction = (target.transform.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
            //gameObject.transform.LookAt(target.transform.position);
        }
        float moveAmount = moveSpeed* Time.deltaTime;
        float verticalAmount = verticalSpeed * Time.deltaTime;
        Vector3 currentX= transform.position;
        if (!goingup)
        {
            currentX.y -= verticalAmount;
        }
        else
        {
            currentX.y += verticalAmount;
        }
        if (currentX.y < 1)
        {
            goingup= true;
        }
        else if (currentX.y>1.75f)
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
            ScoreManager.Missed++;
            Debug.Log("missed:" + ScoreManager.Missed);
            comboManager.UpdateCombo();
            spawnManager.CheckHP();
            Destroy(gameObject);
        }
    }
}
