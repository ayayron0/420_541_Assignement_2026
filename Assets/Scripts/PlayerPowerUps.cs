using UnityEngine;

public class PlayerPowerUps : MonoBehaviour
{
    public float JumpTimeLeft { get; private set; }

    public void ActivateJumpBoost(float duration){

        JumpTimeLeft = duration;

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (JumpTimeLeft > 0f){

            JumpTimeLeft -= Time.deltaTime;
            JumpTimeLeft = Mathf.Max(0f, JumpTimeLeft);

        }

    }
}
