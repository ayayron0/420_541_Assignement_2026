using UnityEngine;

public class PlayerPowerUps : MonoBehaviour
{
    public float JumpTimeLeft { get; private set; }
    [SerializeField] private float boostMultiplier = 1.5f;
    private CharacterMovement movement;
    public float SpeedTimeLeft { get; private set; }
    public float ScoreTimeLeft { get; private set; }

    public void ActivateJumpBoost(float duration){

        JumpTimeLeft = duration;

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movement = GetComponent<CharacterMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (JumpTimeLeft > 0f){

            JumpTimeLeft -= Time.deltaTime;
            JumpTimeLeft = Mathf.Max(0f, JumpTimeLeft);

        }

        if (SpeedTimeLeft > 0f){

            SpeedTimeLeft -= Time.deltaTime;
            SpeedTimeLeft = Mathf.Max(0f, SpeedTimeLeft);

            if (SpeedTimeLeft <= 0f){

                movement.SpeedMultiplier = 1f;

            }
        }

        if (ScoreTimeLeft > 0f){

            ScoreTimeLeft -= Time.deltaTime;
            ScoreTimeLeft = Mathf.Max(0f, ScoreTimeLeft);

        }

    }

    public void ActivateSpeedBoost(float duration){

        SpeedTimeLeft = duration;
        movement.SpeedMultiplier = boostMultiplier;

    }

    public void ActivateScoreBoost(float duration){

        ScoreTimeLeft = duration;

    }

}
