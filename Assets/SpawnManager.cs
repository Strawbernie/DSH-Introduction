using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnManager : MonoBehaviour
{
    public GameObject SliceableCubePrefab;
    SpawnManager spawnManager;
    float LeftTimer;
    float RightTimer;
    public float HP;
    public TMP_Text text;
    private void Start()
    {
        spawnManager = FindObjectOfType<SpawnManager>();
        text = FindObjectOfType<TMP_Text>();
        text.text = ("HP:" + spawnManager.HP);
        StartCoroutine(StartDelay());
    }
    IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(5);
        StartCoroutine(SpawnLeft());
        yield return StartCoroutine(SpawnRight());
    }
    IEnumerator SpawnLeft()
    {
        float yPos = (Random.Range(.75f, 1.5f));
        float zPos = (Random.Range(-2f, -2.9f));
        Instantiate(SliceableCubePrefab, new Vector3(3, yPos, zPos), Quaternion.identity);
        LeftTimer = (Random.Range(.7f, 1.8f));
        yield return new WaitForSeconds(LeftTimer);
        yield return StartCoroutine(SpawnLeft());
    }
    IEnumerator SpawnRight()
    {
        float yPos = (Random.Range(.75f, 1.5f));
        float zPos = (Random.Range(-3.1f, -4f));
        Instantiate(SliceableCubePrefab, new Vector3(3, yPos, zPos), Quaternion.identity);
        RightTimer = (Random.Range(.7f, 1.8f));
        yield return new WaitForSeconds(RightTimer);
        yield return StartCoroutine(SpawnRight());
    }
}
