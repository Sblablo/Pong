using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public GameObject leftDisplay;
    public GameObject rightDisplay;
    public GameObject winDisplay;
    
    private int scoreLeft = 0;
    private int scoreRight = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        winDisplay.SetActive(false);
        leftDisplay.GetComponent<TextMeshProUGUI>().text = "0";
        rightDisplay.GetComponent<TextMeshProUGUI>().text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        leftDisplay.GetComponent<TextMeshProUGUI>().text = $"{scoreLeft}";
        rightDisplay.GetComponent<TextMeshProUGUI>().text = $"{scoreRight}";
    }

    public void AddScore(string player)
    {
        if (player == "Left")
        {
            scoreLeft += 1;
            Debug.Log($"Left player scored! {scoreLeft}:{scoreRight}");
            if (scoreLeft >= 11)
            {
                Debug.Log($"Game Over, Left Paddle Wins! {scoreLeft}:{scoreRight}");
                winDisplay.GetComponent<TextMeshProUGUI>().text = $"Game Over!\nLeft Paddle wins";
                StartCoroutine(DisplayWin());
            }
        }
        else
        {
            scoreRight += 1;
            Debug.Log($"Right player scored! {scoreLeft}:{scoreRight}");
            if (scoreRight >= 11)
            {
                Debug.Log($"Game Over, Right Paddle Wins! {scoreLeft}:{scoreRight}");
                winDisplay.GetComponent<TextMeshProUGUI>().text = $"Game Over!\nRight Paddle wins";
                StartCoroutine(DisplayWin());
            }
        }
    }

    private IEnumerator DisplayWin()
    {
        winDisplay.SetActive(true);
        scoreLeft = 0;
        scoreRight = 0;
        yield return new WaitForSeconds(5);
        winDisplay.SetActive(false);
    }
}
