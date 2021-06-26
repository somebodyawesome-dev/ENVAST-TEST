using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timer;
    public Text text;
    bool gameOver;
    public GameObject gameOverPanel;
    // Start is called before the first frame update
    private void Start()
    {
        gameOver = false;
    }
    public void setTimer(int i)
    {
        timer = i;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            if (timer >= 0)
            {
                text.text = "00:" + timer.ToString("0");
                timer -= Time.deltaTime;
            }
            else
            {
                gameOver = true;
                //show lose popup
                gameOverPanel.SetActive(true);

            }
        }
    }
}
