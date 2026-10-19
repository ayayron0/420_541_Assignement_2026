using UnityEngine;

public class ScorePickup : MonoBehaviour
{
    [SerializeField] private int points = 50;
    [SerializeField] private AudioClip pickupSound;

    void OnTriggerEnter(Collider other){

        if (other.CompareTag("Player")){

            PlayerPowerUps powerUps = other.GetComponent<PlayerPowerUps>();
            int collectedPoints = points;

            if (powerUps.ScoreTimeLeft > 0f){

                collectedPoints *= 2;

            }

            GameManager.Instance.AddScore(collectedPoints);
            other.GetComponent<AudioSource>().PlayOneShot(pickupSound);
            Destroy(gameObject);

        }
    }

}
