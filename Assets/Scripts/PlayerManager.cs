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
    private GameObject player_prefab_;
    [SerializeField]
    private PlayerHpGauge player_gauge_;

    private GameObject player_go_;
    private PlayerEntity player_entity_;
    private PlayerMovement player_movement_;
    private PlayerInteraction player_interaction_;
    private PlayerCasting player_casting_;

    [SerializeField]
    private Animator player_animator_;
    public Animator player_animator { get => player_animator_; }

    public GameObject player_go { get => player_go_; }
    public PlayerEntity player { get => player_entity_; }
    public PlayerMovement player_controller { get => player_movement_; }
    public PlayerInteraction player_interaction { get => player_interaction_; }
    public PlayerCasting player_casting { get => player_casting_; }

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
        player_go_ = Instantiate(player_prefab_, Vector3.zero, Quaternion.identity);
        player_movement_ = player_go_.GetComponent<PlayerMovement>();
        player_entity_ = player_go_.GetComponent<PlayerEntity>();
        player_interaction_ = player_go_.GetComponent<PlayerInteraction>();
        player_casting_ = player_go.GetComponent<PlayerCasting>();
        player_animator_ = player_go_.GetComponent<Animator>();
        player_go_.GetComponent<SpriteRenderer>().sprite = player_entity_.status_data.obj_sprite;
        player_interaction.init();
        player_movement_.init();
        player_entity_.init();
        player_movement_.clear();
    }
    public void movePosition(Vector2 _vec)
    {
        player_go_.transform.position = _vec;
        player_movement_.clear();
    }
    public void hitDamage(int _damage)
    {
        player_entity_.hitDamage(_damage);
        player_gauge_.updateHpGauge(player_entity_.getHpPersent());
    }
}