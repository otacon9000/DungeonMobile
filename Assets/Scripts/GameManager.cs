using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("GameManager is null");
            }
            return _instance;
        }
        
    }

    public bool HasKeyToCastle { get; set; }

    private Player _player;

    private void Awake()
    {
        _instance = this;
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    public void UpdatePlayerGemsFromAds(int gemsValue)
    {
        _player.AddGems(gemsValue);
        UIManager.Instance.OpenShop(_player.GetGems());
    }
}
