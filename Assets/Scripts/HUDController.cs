using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private TMP_Text healthText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + GameManager.Instance.Score;
        healthText.text = "Health: " + playerHealth.Health;
    }
}
