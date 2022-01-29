using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    private float gameTime = 90f;
    public Text displayTime;
    public Text displayCountdown;
    private bool countingDown = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(countdown());
    }

    // Update is called once per frame
    void Update()
    {
        if (countingDown == false)
        {
            if (gameTime <= 0f)
            {
                Time.timeScale = 0;
                displayTime.gameObject.SetActive(false);
                displayCountdown.gameObject.SetActive(true);
                displayCountdown.text = "FINISH!";
            }
            else
            {
                gameTime -= Time.deltaTime;
            }

            int min = Mathf.FloorToInt(gameTime / 60f);
            float sec = gameTime - (60 * min);

            if (min > 0)
            {
                displayTime.text = min + ":" + sec.ToString("00.00");
            }
            else
            {
                displayTime.text = sec.ToString("00.00");
            }
        }
    }

    IEnumerator countdown()
    {
        displayCountdown.text = "3";
        yield return new WaitForSeconds(1);
        displayCountdown.text = "2";
        yield return new WaitForSeconds(1);
        displayCountdown.text = "1";
        yield return new WaitForSeconds(1);
        displayCountdown.text = "GO!";
        displayTime.gameObject.SetActive(true);
        countingDown = false;
        yield return new WaitForSeconds(1);
        displayCountdown.text = "";
        displayCountdown.gameObject.SetActive(false);
    }

}
