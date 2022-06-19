using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int gold = 0;
    public TextMeshProUGUI goldText;
    public TextMeshProUGUI powerText;
    HurtEnemy hurtEnem;

    // Start is called before the first frame update
    void Start()
    {
        hurtEnem = FindObjectOfType<HurtEnemy>();
    }

    // Update is called once per frame
    void Update()
    {
        
        goldText.text = "Gold: " + gold;
        powerText.text = "Power: " + hurtEnem.damageToGive;
    }
    public void RestartTheGame()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void AddGold(int amount)
    {
        gold += amount;
    }
    public int GetGold()
    {
        return gold;
    }
}
