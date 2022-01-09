using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private static PlayerManager _instance =  null;
    [SerializeField]
    private GameObject _player_prefab;
    private GameObject _player_object;
    private Player _player;
    private PlayerController _player_controller;

    public Player player { get => _player; }

    public static PlayerManager instance
    {
        get
        {
            if(_instance == null)   { return null; }
            else                    { return _instance; }
        }
    }
    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void Start()
    {
        init();
    }
    private void Update()
    {
        _player_controller.movePlayer();
    }
    private void init()
    {
        _player_object = Instantiate(_player_prefab, new Vector3(0, 0, 0), Quaternion.identity);
        _player_controller = _player_object.GetComponent<PlayerController>();
        _player = _player_object.GetComponent<Player>();
    }
}
