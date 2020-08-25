using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The HUD
/// </summary>
public class HUD : MonoBehaviour
{
    [SerializeField]
    Text scoreText;
    float elapsedSeconds = 0f;
    bool GameTimerRunning = true;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        if (GameTimerRunning)
        {
            elapsedSeconds += Time.deltaTime;
            int elapsedSecondsAbsolute = (int)elapsedSeconds;
            scoreText.text = elapsedSecondsAbsolute.ToString();
        }
    }

    public void StopGameTimer()
    {
        GameTimerRunning = false;
    }
}
