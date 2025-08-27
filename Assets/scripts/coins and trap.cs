using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemControl : MonoBehaviour
{
    public int coins = 0;          // Number of coins collected
    public int health = 100;       // Player health
    public int maxHealth = 100;    // Maximum health
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If we touch a coin
        if (collision.CompareTag("Coin"))
        {
            coins++;
            Debug.Log("Coin collected! Total coins: " + coins);

            if (audioSource != null)
            {
                audioSource.Play(); // play coin sound
            }

            // Destroy the coin (destroy whole root if coin has children)
            Destroy(collision.transform.root.gameObject);
        }

        // If we touch an enemy
        if (collision.CompareTag("Enemy"))
        {
            health -= 100;
            Debug.Log("Hit by enemy! Health: " + health);

            Destroy(collision.gameObject);

            if (health <= 0)
            {
                Debug.Log("Game Over");
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}