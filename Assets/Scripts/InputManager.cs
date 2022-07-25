using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager _instance;
    public static InputManager instance
    {
        get
        {
            if (_instance == null) { return null; }
            else { return _instance; }
        }
    }
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private Dictionary<KeyCode, Command> key_command_dic_ = new Dictionary<KeyCode, Command>();

    [SerializeField]
    private KeyCode interaction_key_ = KeyCode.G;
    [SerializeField]
    private KeyCode skill_casting_key_ = KeyCode.Space;
    [SerializeField]
    private KeyCode skill_key_1_ = KeyCode.Q;
    [SerializeField]
    private KeyCode skill_key_2_ = KeyCode.W;
    [SerializeField]
    private KeyCode skill_key_3_ = KeyCode.E;
    [SerializeField]
    private KeyCode skill_key_4_ = KeyCode.A;
    [SerializeField]
    private KeyCode skill_key_5_ = KeyCode.S;
    [SerializeField]
    private KeyCode skill_key_6_ = KeyCode.D;
    [SerializeField]
    private KeyCode skill_index_key_1_ = KeyCode.Alpha1;
    [SerializeField]
    private KeyCode skill_index_key_2_ = KeyCode.Alpha2;
    [SerializeField]
    private KeyCode skill_index_key_3_ = KeyCode.Alpha3;
    [SerializeField]
    private KeyCode skill_index_key_4_ = KeyCode.Alpha4;
    [SerializeField]
    private KeyCode skill_index_key_5_ = KeyCode.Alpha5;
    [SerializeField]
    private KeyCode skill_book_activate_ = KeyCode.K;


    private void Update()
    {
        foreach (var command in key_command_dic_.Values)
        {
            command.act();
        }
    }

    public void init()
    {
        key_command_dic_[interaction_key_] = new InterActionCommand(KeyActionType.DOWN, interaction_key_);
        key_command_dic_[skill_casting_key_] = new CastingCommand(KeyActionType.DOWN, skill_casting_key_);
        key_command_dic_[skill_book_activate_] = new SkillInventoryActivateCommand(KeyActionType.DOWN, skill_book_activate_);
        key_command_dic_[skill_key_1_] = new SkillKeyCommand(KeyActionType.DOWN, skill_key_1_, 0);
        key_command_dic_[skill_key_2_] = new SkillKeyCommand(KeyActionType.DOWN, skill_key_2_, 1);
        key_command_dic_[skill_key_3_] = new SkillKeyCommand(KeyActionType.DOWN, skill_key_3_, 2);
        key_command_dic_[skill_key_4_] = new SkillKeyCommand(KeyActionType.DOWN, skill_key_4_, 3);
        key_command_dic_[skill_key_5_] = new SkillKeyCommand(KeyActionType.DOWN, skill_key_5_, 4);
        key_command_dic_[skill_key_6_] = new SkillKeyCommand(KeyActionType.DOWN, skill_key_6_, 5);
        key_command_dic_[skill_index_key_1_] = new SkillSwitchCommand(KeyActionType.DOWN, skill_index_key_1_, 0);
        key_command_dic_[skill_index_key_2_] = new SkillSwitchCommand(KeyActionType.DOWN, skill_index_key_2_, 1);
        key_command_dic_[skill_index_key_3_] = new SkillSwitchCommand(KeyActionType.DOWN, skill_index_key_3_, 2);
        key_command_dic_[skill_index_key_4_] = new SkillSwitchCommand(KeyActionType.DOWN, skill_index_key_4_, 3);
        key_command_dic_[skill_index_key_5_] = new SkillSwitchCommand(KeyActionType.DOWN, skill_index_key_5_, 4);
    }
}
