using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
public List<Cards> deck = new List<Cards>();
    public List<Cards> discardPile = new List<Cards>();
    public Transform[] cardSlots;
    public bool[] availableCardSlots;
    public SatisfactionBar satisfactionBar;
    public int currentHealth = 500;
    int QuestionNumber;
    public GameObject NextLevelButton;
    public GameObject DSHButton;
    public GameObject TryAgainButton;

    public bool cantplay;
    public TextMeshProUGUI question;
    public TextMeshProUGUI deckSizeText;
    public TextMeshProUGUI discardSizeText;
    public TextMeshProUGUI CountDownTimer;
    public float totalTime = 60f;
    bool timerPaused;
    private void Start()
    {
            satisfactionBar.SetMaxHealth(1000);
            satisfactionBar.SetHealth(currentHealth);
            SayNextLine();
            UpdateTimerDisplay();
            InvokeRepeating("UpdateTimer", 1f, 1f);
    }
    public void StartNextLevel()
    {
        timerPaused= false;
        UpdateTimerDisplay();
        InvokeRepeating("UpdateTimer", 1f, 1f);
        totalTime = 60f;
        cantplay = false;
        SayNextLine();
        NextLevelButton.SetActive(false);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("XRInteractionTookitDemo");
    }
    public void TryAgain()
    {
        SceneManager.LoadScene("CardBattling");
    }
    void UpdateTimer()
    {
        if(!timerPaused)
        {
            totalTime -= 1f;
            currentHealth -= 5;
            satisfactionBar.SetHealth(currentHealth);
            UpdateTimerDisplay();
        }

        if (totalTime <= 0f)
        {
            question.text = ("You failed to impress me.");
            DSHButton.SetActive(true);
            TryAgainButton.SetActive(true);
            cantplay = true;
            CancelInvoke("UpdateTimer");
        }
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(totalTime / 60f);
        int seconds = Mathf.FloorToInt(totalTime % 60f);

        string timerString = string.Format("{0:00}:{1:00}", minutes, seconds);
        CountDownTimer.text = timerString;
    }
    public void DrawCard()
    {
        if(deck.Count >= 1){
            Cards randCard = deck[Random.Range(0,deck.Count)];

            for (int i =0; i<availableCardSlots.Length; i++)
            {
                if (availableCardSlots[i])
                {
                    randCard.gameObject.SetActive(true);
                    randCard.handIndex= i;

                    randCard.transform.position = cardSlots[i].position;
                    randCard.hasBeenPlayed = false;

                    availableCardSlots[i] = false;
                    deck.Remove(randCard);
                    return;
                }
            }
        }
    }
    public void ApplyEffect(int ID,Card card)
    {
        switch (ID)
        {
            case 0:
                if (satisfactionBar.Type == 0)
                {
                    currentHealth +=(50*2);
                }
                else if (satisfactionBar.Type ==2)
                {
                    currentHealth +=50;
                }
                else
                {
                    currentHealth -= 50;
                }
                satisfactionBar.SetHealth(currentHealth);
                break;
            case 1:
                if (satisfactionBar.Type == 0)
                {
                    currentHealth +=(60 * 2);
                }
                else if (satisfactionBar.Type == 2)
                {
                    currentHealth +=40;
                }
                else
                {
                    currentHealth -= 50;
                }
                satisfactionBar.SetHealth(currentHealth);
                break;
            case 2:
                if (satisfactionBar.Type == 0)
                {
                    currentHealth +=(70 * 2);
                }
                else if (satisfactionBar.Type == 2)
                {
                    currentHealth +=30;
                }
                else
                {
                    currentHealth -= 50;
                }
                satisfactionBar.SetHealth(currentHealth);
                break;
            case 3:
                if (satisfactionBar.Type == 0)
                {
                    currentHealth +=(80 * 2);
                }
                else if (satisfactionBar.Type == 2)
                {
                    currentHealth +=20;
                }
                else
                {
                    currentHealth -= 50;
                }
                satisfactionBar.SetHealth(currentHealth);
                break;
            case 4:
                if (satisfactionBar.Type == 0)
                {
                    currentHealth +=(90 * 2);
                }
                else if (satisfactionBar.Type == 2)
                {
                    currentHealth +=10;
                }
                else
                {
                    currentHealth -= 50;
                }
                satisfactionBar.SetHealth(currentHealth);
                break;
            case 5:
                if (satisfactionBar.Type == 2)
                {
                    currentHealth += (50 * 2);
                }
                else if (satisfactionBar.Type == 1)
                {
                    currentHealth += 50;
                }
                else
                {
                    currentHealth -= 50;
                }
                satisfactionBar.SetHealth(currentHealth);
                break;
            case 6:
                if (satisfactionBar.Type == 2)
                {
                    currentHealth += (60 * 2);
                }
                else if (satisfactionBar.Type == 1)
                {
                    currentHealth += 40;
                }
                else
                {
                    currentHealth -= 50;
                }
                satisfactionBar.SetHealth(currentHealth);
                break;
            case 7:
                if (satisfactionBar.Type == 2)
                {
                    currentHealth += (70 * 2);
                }
                else if (satisfactionBar.Type == 1)
                {
                    currentHealth += 30;
                }
                else
                {
                    currentHealth -= 50;
                }
                satisfactionBar.SetHealth(currentHealth);
                break;
            case 8:
                if (satisfactionBar.Type == 2)
                {
                    currentHealth += (80 * 2);
                }
                else if (satisfactionBar.Type == 1)
                {
                    currentHealth += 20;
                }
                else
                {
                    currentHealth -= 50;
                }
                satisfactionBar.SetHealth(currentHealth);
                break;
            case 9:
                if (satisfactionBar.Type == 2)
                {
                    currentHealth += (90 * 2);
                }
                else if (satisfactionBar.Type == 1)
                {
                    currentHealth += 10;
                }
                else
                {
                    currentHealth -= 50;
                }
                satisfactionBar.SetHealth(currentHealth);
                break;
            case 10:
                if (satisfactionBar.Type == 1)
                {
                    currentHealth += (50 * 2);
                }
                else if (satisfactionBar.Type == 0)
                {
                    currentHealth += 50;
                }
                else
                {
                    currentHealth -= 50;
                }
                satisfactionBar.SetHealth(currentHealth);
                break;
            case 11:
                if (satisfactionBar.Type == 1)
                {
                    currentHealth += (60 * 2);
                }
                else if (satisfactionBar.Type == 0)
                {
                    currentHealth += 40;
                }
                else
                {
                    currentHealth -= 50;
                }
                satisfactionBar.SetHealth(currentHealth);
                break;
            case 12:
                if (satisfactionBar.Type == 1)
                {
                    currentHealth += (70 * 2);
                }
                else if (satisfactionBar.Type == 0)
                {
                    currentHealth += 30;
                }
                else
                {
                    currentHealth -= 50;
                }
                satisfactionBar.SetHealth(currentHealth);
                break;
            case 13:
                if (satisfactionBar.Type == 1)
                {
                    currentHealth += (80 * 2);
                }
                else if (satisfactionBar.Type == 0)
                {
                    currentHealth += 20;
                }
                else
                {
                    currentHealth -= 50;
                }
                satisfactionBar.SetHealth(currentHealth);
                break;
            case 14:
                if (satisfactionBar.Type == 1)
                {
                    currentHealth += (90 * 2);
                }
                else if (satisfactionBar.Type == 0)
                {
                    currentHealth += 10;
                }
                else
                {
                    currentHealth -= 50;
                }
                satisfactionBar.SetHealth(currentHealth);
                break;
        }
    }
    public void SayNextLine()
    {
        QuestionNumber++;
        switch(QuestionNumber)
        {
            case 1:
                {
                    question.text = ("How can we streamline our current processes to enhance efficiency and reduce bottlenecks?");
                    break;
                }
            case 2:
                {
                    question.text = ("Are our resources, both human and technological, being allocated optimally to maximize productivity and minimize waste?");
                    break;
                }
            case 3:
                {
                    question.text = ("What technologies or tools can we integrate to automate repetitive tasks and improve overall operational efficiency?");
                    break;
                }
            case 4:
                {
                    question.text = ("Which key performance indicators (KPIs) should we prioritize to measure and track our efficiency improvements, and how are we progressing against them?");
                    break;
                }
            case 5:
                {
                    question.text = ("How can we gather feedback from employees on the front lines to identify potential inefficiencies and gather insights into improving our workflows?");
                    break;
                }
            case 6:
                {
                    CancelInvoke("UpdateTimer");
                    timerPaused = true;
                    cantplay = true;
                    satisfactionBar.Type++;
                    if (satisfactionBar.slider.value < 500)
                    {
                        question.text = ("You failed to impress me.");
                        DSHButton.SetActive(true);
                        TryAgainButton.SetActive(true);
                    }
                    else
                    {
                        NextLevelButton.SetActive(true);
                        question.text = ("Thank you, that's all I needed to know");
                    }
                    break;
                }
            case 7:
                {
                    question.text = ("How can we enhance our brand exposure to improve recognition and trust among our target audience? Are there new channels or partnerships that could amplify our brand visibility?");
                    break;
                }
            case 8:
                {
                    question.text = ("What potential risks does our business currently face, and how can we mitigate or manage them effectively? Are there emerging threats that we should be proactive in addressing to minimize exposure?");
                    break;
                }
            case 9:
                {
                    question.text = ("In the digital landscape, how can we optimize our online presence to increase exposure? Are our digital marketing efforts aligned with current trends and customer preferences?");
                    break;
                }
            case 10:
                {
                    question.text = ("What is our level of exposure to competitive forces in the market? How can we differentiate ourselves strategically to minimize vulnerability and gain a competitive edge?");
                    break;
                }
            case 11:
                {
                    question.text = ("What strategies do we have in place to increase our market exposure and reach a wider audience? Are there untapped market segments we should explore?");
                    break;
                }
            case 12:
                {
                    CancelInvoke("UpdateTimer");
                    timerPaused = true;
                    cantplay = true;
                    satisfactionBar.Type++;
                    if (satisfactionBar.slider.value < 500)
                    {
                        question.text = ("You failed to impress me.");
                        DSHButton.SetActive(true);
                        TryAgainButton.SetActive(true);
                    }
                    else
                    {
                        NextLevelButton.SetActive(true);
                        question.text = ("Thank you, that's all I needed to know");
                    }
                    break;
                }
            case 13:
                {
                    question.text = ("What opportunities exist for market expansion that could contribute to increased profits? Should we consider entering new markets, expanding our product/service offerings, or exploring strategic partnerships to drive revenue growth?");
                    break;
                }
            case 14:
                {
                    question.text = ("How can we enhance the value we provide to our customers to justify premium pricing and increase customer loyalty? Are there additional services or features that could be introduced to meet evolving customer needs?");
                    break;
                }
            case 15:
                {
                    question.text = ("What steps are we taking to ensure the financial sustainability of the business? Are there investments we should consider to diversify revenue streams and minimize dependency on specific markets or products?");
                    break;
                }
            case 16:
                {
                    question.text = ("How can we improve our profit margins in the short term and sustainably over the long term? Are there specific product lines or services where we can optimize pricing strategies?");
                    break;
                }
                     case 17:
                {
                    question.text = ("What cost-cutting measures can we implement without compromising product or service quality? Are there operational efficiencies we can achieve to reduce overall costs and boost profitability?");
                    break;
                }
                case 18:
                {
                    CancelInvoke("UpdateTimer");
                    timerPaused = true;
                    cantplay = true;
                    if (satisfactionBar.slider.value < 500)
                    {
                        question.text = ("You failed to impress me.");
                        DSHButton.SetActive(true);
                        TryAgainButton.SetActive(true);
                    }
                    else
                    {
                        question.text = ("You impressed me. Good job!");
                        DSHButton.SetActive(true);
                        TryAgainButton.SetActive(true);
                    }
                    break;
                }
        }
    }
    public void Shuffle()
    {
        if(discardPile.Count >= 1)
        {
            foreach(Cards card in discardPile){
                if (card.bigger)
                {
                    card.OnPointerExit();
                }
                deck.Add(card);
            }

            GameObject[] cardsPlayed = GameObject.FindGameObjectsWithTag("3DCard");
            foreach(GameObject card in cardsPlayed)
            {
                Destroy(card);
            }
            discardPile.Clear();
        }
    }
    private void Update()
    {
        deckSizeText.text = deck.Count.ToString();
        discardSizeText.text = discardPile.Count.ToString();
    }
}
