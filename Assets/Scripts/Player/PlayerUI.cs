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

    public TextMeshProUGUI godmodeStatus;

    public Image gameOverScreen;
    public Transform livesParent;

    public GameObject winScreen;

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

    public void UpdateGodModeStatus(bool status) {
        godmodeStatus.text = "Press P to Activate Godmode: " + status;
    }

    public void ToMenu() {
        SceneManager.LoadScene("MainMenu");
    }

    public GameObject continueButton;
    public void ShowWin() {
        winScreen.SetActive(true);

        if(GameManager.instance.level == 3) {
            continueButton.GetComponentInChildren<TextMeshProUGUI>().text = "Menu";
            continueButton.GetComponent<Button>().onClick.RemoveAllListeners();
            continueButton.GetComponent<Button>().onClick.AddListener(() => {
                SceneManager.LoadScene("Main Menu");
            });
        } else {
            continueButton.GetComponentInChildren<TextMeshProUGUI>().text = "Continue";
            continueButton.GetComponent<Button>().onClick.RemoveAllListeners();
            continueButton.GetComponent<Button>().onClick.AddListener(() => {
                SceneManager.LoadScene("Level" + (GameManager.instance.level + 1));
            });
        }
    }
}
