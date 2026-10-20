using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathPlane : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.RestoreLevelStartScore();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
