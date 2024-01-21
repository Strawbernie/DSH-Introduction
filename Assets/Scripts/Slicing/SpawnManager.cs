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
    float maxRange;
    float zPosMinimum;
    float zPosMaximum;
    public TextMeshProUGUI countdownText;
    public GameObject Tutorial1;
    public GameObject Tutorial2;
    public float totalTime = 120f;
    bool sliceSucces;
    private void Start()
    {
        ScoreManager.Sliced = 0;
        ScoreManager.Missed = 0;
        maxRange = 13;
        zPosMinimum = ScoreManager.armLength * 1.5f;
        zPosMaximum = ScoreManager.armLength * -3.5f;
        spawnManager = FindObjectOfType<SpawnManager>();
        text.text = ("HP:" + spawnManager.HP);
        StartCoroutine(StartDelay());
    }
    void UpdateTimer()
    {
        totalTime -= 1f;
        UpdateTimerDisplay();
        if (totalTime < 60)
        {
            maxRange = 16;
        }
        if (totalTime <= 0f)
        {
            SceneManager.LoadScene("BugSlicingEndScreen");
            CancelInvoke("UpdateTimer");
        }
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(totalTime / 60f);
        int seconds = Mathf.FloorToInt(totalTime % 60f);

        string timerString = string.Format("{0:00}:{1:00}", minutes, seconds);
        countdownText.text = timerString;
    }
    IEnumerator StartDelay()
    {
        float yPos = (Random.Range(.75f, 1.5f));
        float zPos = (Random.Range(zPosMinimum, zPosMaximum));
        yield return new WaitForSeconds(5);
        StartCoroutine(Tutorial());
    }
    IEnumerator Tutorial()
    {
        float yPos = (Random.Range(.75f, 1.5f));
        float zPos = (Random.Range(zPosMinimum, zPosMaximum));
        Tutorial1.SetActive(true);
        Instantiate(SliceableCubePrefab, new Vector3(4, yPos, zPos), Quaternion.Euler(-90f, -90f, 0f));
        yield return new WaitForSeconds(4);
        if (HP == 10||sliceSucces)
        {
            Instantiate(HealPrefab, new Vector3(4, yPos, zPos), Quaternion.Euler(0f, -90f, -90f));
            Tutorial1.SetActive(false);
            Tutorial2.SetActive(true);
            sliceSucces = true;
            yield return new WaitForSeconds(4);
            if (HP == 11)
            {
                StartCoroutine(SpawnLeft());
                Tutorial2.SetActive(false);
                UpdateTimerDisplay();
                InvokeRepeating("UpdateTimer", 1f, 1f);
            }
            else
            {
                HP = 10;
                StartCoroutine(Tutorial());
            }
        }
        else
        {
            HP = 10;
            StartCoroutine(Tutorial());
        }
    }
    IEnumerator SpawnLeft()
    {
        float yPos = (Random.Range(.75f, 1.5f));
        float zPos = (Random.Range(zPosMinimum, zPosMaximum));
        float prefabID = (Random.Range(1, maxRange));
        if (prefabID < 8)
        {
            Instantiate(SliceableCubePrefab, new Vector3(4, yPos, zPos), Quaternion.Euler(-90f, -90f, 0f));
        }
        else if (prefabID < 11)
        {
            Instantiate(UpDownPrefab, new Vector3(4, yPos, zPos), Quaternion.Euler(-90f, -90f, 0f));
        }
        else if(prefabID < 13)
        {
            Instantiate(HealPrefab, new Vector3(4, yPos, zPos), Quaternion.Euler(0f, -90f, -90f));
        }
        else if (prefabID < 14)
        {
            Instantiate(SliceableCubePrefab, new Vector3(4, 1.25f, -1), Quaternion.Euler(-90f, -90f, 0f));
            Instantiate(SliceableCubePrefab, new Vector3(4.1f, 1.25f, -2), Quaternion.Euler(-90f, -90f, 0f));
            Instantiate(SliceableCubePrefab, new Vector3(4.2f, 1.25f, -3), Quaternion.Euler(-90f, -90f, 0f));
            Instantiate(SliceableCubePrefab, new Vector3(4.3f, 1.25f, -4), Quaternion.Euler(-90f, -90f, 0f));
            Instantiate(SliceableCubePrefab, new Vector3(4.4f, 1.25f, -5), Quaternion.Euler(-90f, -90f, 0f));
        }
        else if (prefabID < 15)
        {
            Instantiate(SliceableCubePrefab, new Vector3(4f, 2.2f, -3), Quaternion.Euler(-90f, -90f, 0f));
            Instantiate(SliceableCubePrefab, new Vector3(4.1f, 1.7f, -3), Quaternion.Euler(-90f, -90f, 0f));
            Instantiate(SliceableCubePrefab, new Vector3(4.2f, 1.2f, -3), Quaternion.Euler(-90f, -90f, 0f));
            Instantiate(SliceableCubePrefab, new Vector3(4.3f, .7f, -3), Quaternion.Euler(-90f, -90f, 0f));
            Instantiate(SliceableCubePrefab, new Vector3(4.4f, .2f, -3), Quaternion.Euler(-90f, -90f, 0f));
        }
        else if (prefabID < 16)
        {
            Instantiate(SliceableCubePrefab, new Vector3(4f, 2.2f, -1), Quaternion.Euler(-90f, -90f, 0f));
            Instantiate(SliceableCubePrefab, new Vector3(4.1f, 1.7f, -2), Quaternion.Euler(-90f, -90f, 0f));
            Instantiate(SliceableCubePrefab, new Vector3(4.2f, 1.2f, -3), Quaternion.Euler(-90f, -90f, 0f));
            Instantiate(SliceableCubePrefab, new Vector3(4.3f, .7f, -4), Quaternion.Euler(-90f, -90f, 0f));
            Instantiate(SliceableCubePrefab, new Vector3(4.4f, .2f, -5), Quaternion.Euler(-90f, -90f, 0f));
        }
        LeftTimer = (Random.Range(.45f, .9f));
        yield return new WaitForSeconds(LeftTimer);
        yield return StartCoroutine(SpawnLeft());
    }
   public void CheckHP()
    {
        text.text = ("HP:" + spawnManager.HP);
        if (HP <= 0)
        {
            SceneManager.LoadScene("BugSlicingEndScreen");
        }
    }

    }
