using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayerMovement), typeof(PlayerInteraction), typeof(PlayerUI))]
public class PlayerManager : MonoBehaviour {
    private static PlayerManager _instance = null;
    public static PlayerManager instance {
        get {
            if(_instance == null) {
                _instance = FindObjectOfType<PlayerManager>();
            }

            return _instance;
        }
    }

    private PlayerMovement _playerMovement = null;
    public PlayerMovement playerMovement {
        get {
            if(_playerMovement == null) {
                _playerMovement = GetComponent<PlayerMovement>();
            }

            return _playerMovement;
        }
    }

    private PlayerInteraction _playerInteraction = null;
    public PlayerInteraction playerInteraction {
        get {
            if(_playerInteraction == null) {
                _playerInteraction = GetComponent<PlayerInteraction>();
            }

            return _playerInteraction;
        }
    }

    private PlayerUI _playerUI = null;
    public PlayerUI playerUI {
        get {
            if(_playerUI == null) {
                _playerUI = GetComponent<PlayerUI>();
            }

            return _playerUI;
        }
    }

    private PowerupManager _powerupManager = null;
    public PowerupManager powerupManager {
        get {
            if(_powerupManager == null) {
                _powerupManager = GetComponent<PowerupManager>();
            }

            return _powerupManager;
        }
    }

    private int lives = 3;
    public int GetLives() { return lives; }

    public bool bDead = false;

    public void LoseLife() {
        playerUI.DisableHeart();
        lives--;
        if(lives <= 0) {
            StartCoroutine(Dead());
        }
    }

    public void InstantKill() {
        lives = 0;
        StartCoroutine(Dead());
    }

    private float timeTilReset = 3.0f;
    private IEnumerator Dead() {
        if(!bDead) {
            bDead = true;
            playerUI.ShowGameOverScreen(timeTilReset);
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            GetComponent<Rigidbody>().AddForce(Vector3.right * 5, ForceMode.Impulse);
            yield return new WaitForSeconds(timeTilReset);
            SceneManager.LoadScene("MainMenu");
        }
        yield return null;
    }
}