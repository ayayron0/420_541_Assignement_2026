using UnityEngine;
using TMPro;

public class PowerUpHUD : MonoBehaviour
{
    [SerializeField] private PlayerPowerUps powerUps;

    [SerializeField] private GameObject jumpIndicator;
    [SerializeField] private TMP_Text jumpTimeText;

    [SerializeField] private GameObject speedIndicator;
    [SerializeField] private TMP_Text speedTimeText;

    [SerializeField] private GameObject scoreIndicator;
    [SerializeField] private TMP_Text scoreTimeText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float timeLeft = powerUps.JumpTimeLeft;

        jumpIndicator.SetActive(timeLeft > 0f);
        jumpTimeText.text = Mathf.CeilToInt(timeLeft) + "s";

        float speedTimeLeft = powerUps.SpeedTimeLeft;

        speedIndicator.SetActive(speedTimeLeft > 0f);
        speedTimeText.text = Mathf.CeilToInt(speedTimeLeft) + "s";

        float scoreTimeLeft = powerUps.ScoreTimeLeft;

        scoreIndicator.SetActive(scoreTimeLeft > 0f);
        scoreTimeText.text = Mathf.CeilToInt(scoreTimeLeft) + "s";

    }
}
