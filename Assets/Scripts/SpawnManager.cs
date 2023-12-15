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
        spawnManager = FindObjectOfType<SpawnManager>();
        text = FindObjectOfType<TMP_Text>();
        text.text = ("HP:" + spawnManager.HP);
        StartCoroutine(StartDelay());
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
            Instantiate(SliceableCubePrefab, new Vector3(4, yPos, zPos), Quaternion.identity);
        }
        else if (prefabID < 8)
        {
            Instantiate(UpDownPrefab, new Vector3(4, yPos, zPos), Quaternion.identity);
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
            SceneManager.LoadScene("Titlescreen");
        }
    }
}
