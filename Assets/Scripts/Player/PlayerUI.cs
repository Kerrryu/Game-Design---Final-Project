using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    public TextMeshProUGUI coinsText;

    private void Awake() {
        GameManager.CoinsChanged += CoinValueChanges;
    }

    private void CoinValueChanges() {
        coinsText.text = "Coins: " + GameManager.COINS;
    }
}
