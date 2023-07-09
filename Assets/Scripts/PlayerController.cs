using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public TextMeshProUGUI healthLabel;
    public float health;
    public float batHealth;
    public float maxLives = 3f;
    public SendToGoogle sendtogoogle;
    public MessageToPlayer messageToPlayer;
    public bool isBat;
    // Start is called before the first frame update
    void Start()
    {
        isBat = false;
        batHealth = 2;
        health = maxLives;
        healthLabel.text = "Health: " + health;
        gameObject.SetActive(true);
        sendtogoogle = GetComponent<SendToGoogle>();
    }

    public float getHealthy()
    {
        return health;
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("RockEnemy"))
        {
            TakeDamage(1f, "rock");
        }
    }
    
    

    public void TakeDamage(float damage, string enemy)
    {
        if (isBat)
        {
            if (batHealth > 0)
            {
                batHealth -= damage;
                healthLabel.text = "Health: " + health;
                Debug.Log("Bat Health" + batHealth);
            }
            if (batHealth <= 0)
            {
                messageToPlayer.DisplayDied();
                Vector2 playerposition = transform.position;
                sendtogoogle.Send(System.DateTime.Now, playerposition, enemy);
                gameObject.SetActive(false);
            }
        }
        else
        {
            if (health > 0)
            {
                health -= damage;
                healthLabel.text = "Health: " + health;
            }
            if (health <= 0)
            {
                messageToPlayer.DisplayDied();
                Vector2 playerposition = transform.position;
                sendtogoogle.Send(System.DateTime.Now, playerposition, enemy);
                gameObject.SetActive(false);
            }
        }
    }
}
