using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private static PlayerManager _instance =  null;

    public static PlayerManager instance
    {
        get
        {
            if(_instance == null)   { return null; }
            else                    { return _instance; }
        }
    }

    [SerializeField]
    private GameObject _player_prefab;
    [SerializeField]
    private PlayerHpGauge _player_gauge;

    private GameObject _player_object;
    private PlayerEntity _player;
    private PlayerController _player_controller;

    public GameObject player_object { get => _player_object; }
    public PlayerEntity player { get => _player; }
    public PlayerController player_controller { get => _player_controller; }

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

    private void Update()
    {
    }
    
    public void init()
    {
        _player_object = Instantiate(_player_prefab, StageManager.instance.curr_real_pos, Quaternion.identity);
        _player_controller = _player_object.GetComponent<PlayerController>();
        _player = _player_object.GetComponent<PlayerEntity>();
        _player_object.GetComponent<SpriteRenderer>().sprite = _player.status_data.obj_sprite;
    }
    public void movePlayer(Vector2 _vec)
    {
        _player_object.transform.position = _vec;
    }
    public void hitDamage(int _damage)
    {
        _player.hitDamage(_damage);
        _player_gauge.updateHpGauge(_player.getHpPersent());
    }
}