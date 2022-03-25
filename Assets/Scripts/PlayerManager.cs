using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private static PlayerManager _instance =  null;
    [SerializeField]
    private GameObject _player_prefab;
    [SerializeField]
    private PlayerHpGauge _player_gauge;
    private GameObject _player_object;
    private PlayerEntity _player;
    private PlayerController _player_controller;

    private bool isFreeze = true;

    public PlayerEntity player { get => _player; }

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
        StartCoroutine(delay(1f));
    }
    private void Update()
    {
        if (isFreeze) return;
        _player_controller.movePlayer(_player.player_data.speed);
    }
    public void init()
    {
        _player_object = Instantiate(_player_prefab, StageManager.instance.getCurrStagePlayerSpawnPos(), Quaternion.identity);
        _player_controller = _player_object.GetComponent<PlayerController>();
        _player = _player_object.GetComponent<PlayerEntity>();
        _player_object.GetComponent<SpriteRenderer>().sprite = _player.player_data.obj_sprite;
    }
    public void hitDamage(int _damage)
    {
        _player.hitDamage(_damage);
        _player_gauge.updateHpGauge(_player.getHpPersent());
    }
    private IEnumerator delay(float _delay_time)
    {
        yield return new WaitForSeconds(_delay_time);
        isFreeze = false;
    }

}