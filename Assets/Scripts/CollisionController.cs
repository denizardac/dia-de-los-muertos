using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class CollisionController : MonoBehaviour
{
    private int collisionCount = 0;
    private int score = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI warningText; 
    public GameObject tapText;

    public GameManager gameManager;
    private Rigidbody2D rb;

    private void Start()
    {

        UpdateScoreText();

        tapText.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(false);
        warningText.gameObject.SetActive(false); 

    }

    private void Update()
    {
        if (gameManager.gameStarted)
        {
            tapText.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
   {

    rb = GetComponent<Rigidbody2D>();

        if (collision.CompareTag("Poop")) 
        {
            collisionCount++;
            Destroy(collision.gameObject);

            if (collisionCount == 1)
            {
                ShowWarning();
            }

            if (collisionCount >= 2)
            {
                GameOver();
            }
        }

        else if (collision.CompareTag("Foods"))
        {
            score += 10;
            Destroy(collision.gameObject);
            UpdateScoreText();
        }
        
        else if (collision.CompareTag("Walls"))
        {
            	rb.velocity = Vector2.zero; 
                rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
               

        }
        
   }
   private void UpdateScoreText()
    {
        scoreText.text = " " + score;
    }

    private void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        SceneManager.LoadScene("SampleScene");

    }

    private void ShowWarning()
    {
        warningText.gameObject.SetActive(true);

        Invoke("HideWarning", 2f); 
    }

    private void HideWarning()
    {
        warningText.gameObject.SetActive(false);
    }
}

