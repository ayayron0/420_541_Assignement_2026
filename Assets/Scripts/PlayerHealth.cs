using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int startingHealth = 3;
    public int Health { get; private set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Health = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(){

        Health -= 1;
        Debug.Log("Health: " + Health);

        if (Health <= 0){

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }

    }

}
