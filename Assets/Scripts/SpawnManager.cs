using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    public GameObject SliceableCubePrefab;
    public GameObject UpDownPrefab;
    public GameObject HealPrefab;
    SpawnManager spawnManager;
    float LeftTimer;
    float RightTimer;
    public float HP;
    public TMP_Text text;
    private void Start()
    {
        ScoreManager.Sliced = 0;
        ScoreManager.Missed= 0;
        spawnManager = FindObjectOfType<SpawnManager>();
        text.text = ("HP:" + spawnManager.HP);
        StartCoroutine(StartDelay());
        StartCoroutine(Timer());
    }
    IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(5);
        yield return StartCoroutine(SpawnLeft());
    }
    IEnumerator SpawnLeft()
    {
        float yPos = (Random.Range(.75f, 1.5f));
        float zPos = (Random.Range(3f, -7f));
        float prefabID = (Random.Range(1, 16));
        if (prefabID < 8)
        {
            Instantiate(SliceableCubePrefab, new Vector3(4, yPos, zPos), Quaternion.Euler(-90f, -90f, 0f));
        }
        else if (prefabID < 11)
        {
            Instantiate(UpDownPrefab, new Vector3(4, yPos, zPos), Quaternion.Euler(-90f, -90f, 0f));
        }
        else if (prefabID < 12)
        {
            Instantiate(SliceableCubePrefab, new Vector3(4, 1.25f, -1), Quaternion.Euler(-90f, -90f, 0f));
            Instantiate(SliceableCubePrefab, new Vector3(4.1f, 1.25f, -2), Quaternion.Euler(-90f, -90f, 0f));
            Instantiate(SliceableCubePrefab, new Vector3(4.2f, 1.25f, -3), Quaternion.Euler(-90f, -90f, 0f));
            Instantiate(SliceableCubePrefab, new Vector3(4.3f, 1.25f, -4), Quaternion.Euler(-90f, -90f, 0f));
            Instantiate(SliceableCubePrefab, new Vector3(4.4f, 1.25f, -5), Quaternion.Euler(-90f, -90f, 0f));
        }
        else if (prefabID < 13)
        {
            Instantiate(SliceableCubePrefab, new Vector3(4f, 2.2f, -3), Quaternion.Euler(-90f, -90f, 0f));
            Instantiate(SliceableCubePrefab, new Vector3(4.1f, 1.7f, -3), Quaternion.Euler(-90f, -90f, 0f));
            Instantiate(SliceableCubePrefab, new Vector3(4.2f, 1.2f, -3), Quaternion.Euler(-90f, -90f, 0f));
            Instantiate(SliceableCubePrefab, new Vector3(4.3f, .7f, -3), Quaternion.Euler(-90f, -90f, 0f));
            Instantiate(SliceableCubePrefab, new Vector3(4.4f, .2f, -3), Quaternion.Euler(-90f, -90f, 0f));
        }
        else if (prefabID < 14)
        {
            Instantiate(SliceableCubePrefab, new Vector3(4f, 2.2f, -1), Quaternion.Euler(-90f, -90f, 0f));
            Instantiate(SliceableCubePrefab, new Vector3(4.1f, 1.7f, -2), Quaternion.Euler(-90f, -90f, 0f));
            Instantiate(SliceableCubePrefab, new Vector3(4.2f, 1.2f, -3), Quaternion.Euler(-90f, -90f, 0f));
            Instantiate(SliceableCubePrefab, new Vector3(4.3f, .7f, -4), Quaternion.Euler(-90f, -90f, 0f));
            Instantiate(SliceableCubePrefab, new Vector3(4.4f, .2f, -5), Quaternion.Euler(-90f, -90f, 0f));
        }
        else
        {
            Instantiate(HealPrefab, new Vector3(4, yPos, zPos), Quaternion.identity);
        }
        LeftTimer = (Random.Range(.45f, .9f));
        yield return new WaitForSeconds(LeftTimer);
        yield return StartCoroutine(SpawnLeft());
    }
   public void CheckHP()
    {
        text.text = ("HP:" + spawnManager.HP);
        if (HP < 0)
        {
            SceneManager.LoadScene("BugSlicingEndScreen");
        }
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(100);
        SceneManager.LoadScene("BugSlicingEndScreen");
    }

    }
