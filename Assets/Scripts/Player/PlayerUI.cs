using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI levelText;

    private void Awake() {
        GameManager.CoinsChanged += CoinValueChanges;
    }

    private void CoinValueChanges() {
        coinsText.text = "Coins: " + GameManager.COINS;
    }

    public void PushPause() {
        if(Time.timeScale == 0) {
            Time.timeScale = 1;
        } else {
            Time.timeScale = 0;
        }
    }

    public void PushExit() {
        SceneManager.LoadScene("MainMenu");
    }
}
