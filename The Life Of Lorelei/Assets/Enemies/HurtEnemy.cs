using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    
    public int damageToGive = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            EnemyHealthManager eHealthMan;
            eHealthMan = other.gameObject.GetComponent<EnemyHealthManager>();
            eHealthMan.HurtEnemy(damageToGive);
        }
        if (other.tag == "GoldChest")
        {
            GameManager gameMan;
            gameMan = FindObjectOfType<GameManager>();
            gameMan.GetComponent<GameManager>().AddGold(50);
            Destroy(other.gameObject);
        }
        if (other.tag == "SilverChest")
        {
            GameManager gameMan;
            gameMan = FindObjectOfType<GameManager>();
            gameMan.GetComponent<GameManager>().AddGold(25);
            Destroy(other.gameObject);
        }
        if(other.tag == "HealthBox")
        {
            GameManager gameMan;
            gameMan = FindObjectOfType<GameManager>();
            if (gameMan.GetGold() >= 10)
            {
                HealthManager healthMan;
                healthMan = FindObjectOfType<HealthManager>();
                healthMan.AddHealth();
                gameMan.AddGold(-5);
            }
        }
        if (other.tag == "PowerBox")
        {
            GameManager gameMan;
            gameMan = FindObjectOfType<GameManager>();
            HealthManager healthMan;
            healthMan = FindObjectOfType<HealthManager>();
            if(gameMan.GetGold() >= 100)
            {
                if (healthMan.currentHealth <= 80)
                {
                    damageToGive += 1;
                    other.gameObject.SetActive(false);
                    gameMan.AddGold(-100);
                }
                
            }
        }
    }
}
