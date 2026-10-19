using UnityEngine;
using TMPro;

public class EndScene : MonoBehaviour
{
    [SerializeField] private TMP_Text finalScoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (GameManager.Instance != null){

            finalScoreText.text = "Final Score: " + GameManager.Instance.Score;

        }else{

            finalScoreText.text = "Final Score: 0";

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
