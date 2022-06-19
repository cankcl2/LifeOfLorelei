using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

    private bool flashActive;
    [SerializeField]
    private float flashLength = 0.5f;
    private float flashCounter = 0f;
    private SpriteRenderer playerSprite;


    void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        #region Flash Animation
        if (flashActive)
        {
            if (flashCounter > flashLength * .99f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else if (flashCounter > flashLength * .82f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }
            else if (flashCounter > flashLength * .66f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else if (flashCounter > flashLength * .49f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }
            else if (flashCounter > flashLength * .33f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else if (flashCounter > flashLength * .16f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }
            else if (flashCounter > 0)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
                flashActive = false;
            }
            flashCounter -= Time.deltaTime;
        }
        #endregion

    }

    public void HurtPlayer(int damageToGive)
    {
        currentHealth -= damageToGive;
        flashActive = true;
        flashCounter = flashLength;

        if (currentHealth <= 0)
        {
            GameManager gameMan;
            gameMan = FindObjectOfType<GameManager>().gameObject.GetComponent<GameManager>();
            gameMan.RestartTheGame();
        }
    }
    public void AddHealth()
    {
        currentHealth += 5;
    }
}
    
