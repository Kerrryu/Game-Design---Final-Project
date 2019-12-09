using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;

public class PlayerUI : MonoBehaviour
{
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI levelText;

    public Image gameOverScreen;
    public Transform livesParent;

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

    public void ShowGameOverScreen(float time) {
        gameOverScreen.transform.localScale = new Vector3(10,10,1);
        gameOverScreen.gameObject.SetActive(true);
        gameOverScreen.transform.DOScale(new Vector3(1,1,1), time);
    }

    public void DisableHeart() {
        var heart = livesParent.GetChild(PlayerManager.instance.GetLives()-1);
        heart.gameObject.SetActive(false);
    }
}
