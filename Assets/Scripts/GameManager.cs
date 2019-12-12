using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance = null;
    public static GameManager instance { 
        get {
            if(_instance == null) {
                _instance = FindObjectOfType<GameManager>();
            }

            return _instance;
        }
    }
    public bool debugging = false;

    public LayerMask clickLayerMask;

    private static int _coins = 0;
    public static int COINS {
        get {
            return PlayerPrefs.GetInt("coins");
        }

        set {
            value = Mathf.Max(0, value);
            _coins = value;

            PlayerPrefs.SetInt("coins", _coins);

            if(CoinsChanged != null) {
                CoinsChanged();
            }
        }
    }
    public static System.Action CoinsChanged;

    private int _level = 1;
    public int level {
        get {
            return _level;
        }

        set {
            _level = value;
            StartCoroutine(DisplayLevel());
        }
    }

    private void Awake() {
        DontDestroyOnLoad(gameObject);
        StartGame();
    }

    public void StartGame() {
        level = 1;
    }

    private IEnumerator DisplayLevel() {
        PlayerManager.instance.playerUI.levelText.text = "Level " + level;

        Vector3 startingPosition = PlayerManager.instance.playerUI.levelText.rectTransform.position;
        Vector3 endPosition = startingPosition;
        endPosition.x += Screen.width/2 - PlayerManager.instance.playerUI.levelText.rectTransform.rect.width/2;
        endPosition.y -= Screen.height/2 - PlayerManager.instance.playerUI.levelText.rectTransform.rect.height/2;

        PlayerManager.instance.playerUI.levelText.rectTransform.DOMove(endPosition, 1f);

        yield return new WaitForSeconds(3.0f);

        PlayerManager.instance.playerUI.levelText.rectTransform.DOMove(startingPosition, 1f);
    }
}
