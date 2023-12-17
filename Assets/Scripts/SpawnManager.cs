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
        text = FindObjectOfType<TMP_Text>();
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
        float prefabID = (Random.Range(1, 9));
        if (prefabID < 6)
        {
            Instantiate(SliceableCubePrefab, new Vector3(4, yPos, zPos), Quaternion.Euler(-90f, -90f, 0f));
        }
        else if (prefabID < 8)
        {
            Instantiate(UpDownPrefab, new Vector3(4, yPos, zPos), Quaternion.Euler(-90f, -90f, 0f));
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
