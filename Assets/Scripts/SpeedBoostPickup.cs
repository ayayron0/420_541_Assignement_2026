using UnityEngine;

public class SpeedBoostPickup : MonoBehaviour
{
    [SerializeField] private float duration = 5f;
    [SerializeField] private float respawnDelay = 30f;
    [SerializeField] private GameObject visuals;
    [SerializeField] private AudioClip pickupSound;

    void OnTriggerEnter(Collider other){

        PlayerPowerUps powerUps = other.GetComponent<PlayerPowerUps>();

        if (powerUps == null){

            return;

        }

        powerUps.ActivateSpeedBoost(duration);
        GetComponent<AudioSource>().PlayOneShot(pickupSound);

        visuals.SetActive(false);
        GetComponent<Collider>().enabled = false;

        Invoke(nameof(Reappear), respawnDelay);
    }

    void Reappear(){

        visuals.SetActive(true);
        GetComponent<Collider>().enabled = true;

    }

}
