using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
}