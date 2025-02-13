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
    public PowerUp PowerUp;
    public PowerDown PowerDown;
    
    private int scoreLeft = 0;
    private int scoreRight = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        winDisplay.SetActive(false);
        leftDisplay.GetComponent<TextMeshProUGUI>().text = "0";
        rightDisplay.GetComponent<TextMeshProUGUI>().text = "0";
        if (Random.Range(0, 2) == 0)
            StartCoroutine(SpawnPowerUp(Random.Range(5,10)));
        else
            StartCoroutine(SpawnPowerDown(Random.Range(5,10)));
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
            StartCoroutine(AnimGreen(leftDisplay));
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
            StartCoroutine(AnimGreen(rightDisplay));
            if (scoreRight >= 11)
            {
                Debug.Log($"Game Over, Right Paddle Wins! {scoreLeft}:{scoreRight}");
                winDisplay.GetComponent<TextMeshProUGUI>().text = $"Game Over!\nRight Paddle wins";
                StartCoroutine(DisplayWin());
            }
        }

        if (Random.Range(0, 2) == 0)
            StartCoroutine(SpawnPowerUp(Random.Range(5,10)));
        else
            StartCoroutine(SpawnPowerDown(Random.Range(5,10)));
    }

    private IEnumerator DisplayWin()
    {
        winDisplay.SetActive(true);
        scoreLeft = 0;
        scoreRight = 0;
        yield return new WaitForSeconds(5);
        winDisplay.SetActive(false);
    }

    private IEnumerator AnimGreen(GameObject display)
    {
        display.GetComponent<TextMeshProUGUI>().color = Color.green;
        yield return new WaitForSeconds(1);
        display.GetComponent<TextMeshProUGUI>().color = Color.white;
    }

    private IEnumerator SpawnPowerUp(int time)
    {
        yield return new WaitForSeconds(time);
        PowerUp.transform.position = new Vector3(10.12f, 0f, 0f);
        Instantiate(PowerUp);
    }
    private IEnumerator SpawnPowerDown(int time)
    {
        yield return new WaitForSeconds(time);
        PowerDown.transform.position = new Vector3(10.12f, 0f, 0f);
        Instantiate(PowerDown);
    }
}
