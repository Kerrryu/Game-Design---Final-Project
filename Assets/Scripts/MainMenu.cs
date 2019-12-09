using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI coinsText;

    private void Start() {
        StartCoroutine(MoveTitle());

        coinsText.text = "Coins: " + PlayerPrefs.GetInt("coins");
    }

    IEnumerator MoveTitle() {
        while(true) {
            titleText.transform.DOShakeRotation(2.0f, 20);
            yield return new WaitForSeconds(2.0f);
        }
    }

    public void LaunchLevel(int levelId) {
        SceneManager.LoadScene("Level_" + levelId);
    }

    public void ExitGame() {
        Application.Quit();
    }
}
