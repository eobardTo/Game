using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using System;

public class GameController : Singleton<GameController>
{

    public int money;

    [Header("Upgrades")]
    [SerializeField] int MaxHPPrice = 50;
    [SerializeField] int RegenPrice = 50;
    [SerializeField] int PistolDmgPrice = 50;
    [SerializeField] int PistolFRPrice = 50;

    [Header("Components")]

    [SerializeField] Hud hud;
    [SerializeField] GameObject shopMenu;
    [SerializeField] GameObject gameOverMenu;

    [Space]

    [SerializeField] TextMeshProUGUI MaxHPDesc;
    [SerializeField] TextMeshProUGUI RegenDesc;
    [SerializeField] TextMeshProUGUI DmgDesc;
    [SerializeField] TextMeshProUGUI FRDesc;
    [SerializeField] private bool pause = false;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            shopMenu.SetActive(!shopMenu.activeInHierarchy);

            UpdateShop();
            PauseGame();
        }

        hud.money_T.text = "$" + money;
    }

    public void GameOver() {
        
        PauseGame();
        gameOverMenu.GetComponent<Animator>().Play("Death");

    }

    public void AddMoney(int amount)
    {
        money += amount;
    }

    public void WaveCount(int number)
    {
        hud.waveCount_T.text = "Волна:" + number;
    }
    void PauseGame() {

        pause = !pause;
        
        if (pause)
        {
            Time.timeScale = 0;
            player.GetComponent<Player>().disablePlayer = true;
        }
        else
        {
            Time.timeScale = 1;
            player.GetComponent<Player>().disablePlayer = false;
        }

    }
    public bool CheckMoney(int price) {
        if (price > money)        
            return false;

        money -= 50;

        return true;        
    }

    void UpdateShop() {
        MaxHPDesc.text = "Увеличение HP: " + player.GetComponent<Health>().maxHealth;
        RegenDesc.text = "Увеличение регенерации: " + player.GetComponent<Health>().regen;
        DmgDesc.text = "Увеличение урона: " + player.GetComponent<Weapon>().damage;
        FRDesc.text = "Скорострельность: " + Math.Round(player.GetComponent<Weapon>().fireRate,2);
    }
    public void BuyMaxHealth() {
        if (!CheckMoney(MaxHPPrice))
            return;

        player.GetComponent<Health>().maxHealth += 10;
        UpdateShop();
    }
    public void BuyRegen()
    {
        if (!CheckMoney(RegenPrice))
            return;

        player.GetComponent<Health>().regen += 1f;
        UpdateShop();
    }
    public void BuyPistolDmg()
    {
        if (!CheckMoney(PistolDmgPrice))
            return;

        player.GetComponent<Weapon>().damage += 1;
        UpdateShop();
    }
    public void BuyPistolFR()
    {
        if (!CheckMoney(PistolFRPrice))
            return;

        if (player.GetComponent<Weapon>().fireRate > 0)
        {
            player.GetComponent<Weapon>().fireRate += 1f;
        }
        else
        {
            player.GetComponent<Weapon>().fireRate += 5f;
        }

        UpdateShop();
    }

    public void Restart() {

        PauseGame();
        SceneManager.LoadScene("SampleScene");

    }

    public void QuitGame() {
        Application.Quit();
    }
}
