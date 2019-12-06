using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private static int _coins = 0;
    public static int COINS {
        get {
            return _coins;
        }

        set {
            value = Mathf.Max(0, value);
            _coins = value;

            if(CoinsChanged != null) {
                CoinsChanged();
            }
        }
    }
    public static System.Action CoinsChanged;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            GameManager.COINS += 10;
        }
    }
}
