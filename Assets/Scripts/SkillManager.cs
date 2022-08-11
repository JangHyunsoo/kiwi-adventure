using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    private static SkillManager _instance;
    public static SkillManager instance
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

    [SerializeField]
    private SkillInventoryUI skill_inventory_ui_;
    [SerializeField]
    private SkillInfoCardUI skill_info_card_ui_;
    [SerializeField]
    private SkillBookInfoCardUI skill_book_info_card_ui_;
    [SerializeField]
    private SkillEquipmentScrollUI skill_equipment_scroll_ui_;
    [SerializeField]
    private SkillCommandUI skill_command_ui_;
    [SerializeField]
    private SkillInventory skill_inventory_;

    private int BOOK_SIZE = 3;

    private SkillSlotType curr_book_index_ = SkillSlotType.TWO;
    private int curr_skill_index_ = 0;
    public int curr_skill_index { get => curr_skill_index_; }
    public SkillSlotType curr_book_index { get => curr_book_index_; }
    public int have_skill_count { get => skill_inventory_.have_skill_slot_count; }

    public void init()
    {
        skill_inventory_.init();
        skill_inventory_ui_.init();
        skill_equipment_scroll_ui_.init();
        skill_command_ui_.init();
    }

    public void setSkillInventoryActivate(bool _condition)
    {
        skill_inventory_ui_.setActivate(_condition);
    }

    public void addSkill(Skill _skill)
    {
        skill_inventory_.addSkillToHave(_skill);
    }

    public void updateSkillInfoCard(int _slot_no, SkillSlotType _book_typye)
    {
        skill_info_card_ui_.gameObject.active = true;
        skill_book_info_card_ui_.gameObject.active = false;
        skill_info_card_ui_.setSlotNo(_slot_no, _book_typye);
    }

    public void updateSkillBookInfoCard(SkillSlotType _slot_type)
    {
        skill_info_card_ui_.gameObject.active = false;
        skill_book_info_card_ui_.gameObject.active = true;
        skill_book_info_card_ui_.setBookNo(_slot_type);
    }

    public void moveCurrSkillCursor(int _idx)
    {
        curr_skill_index_ = _idx;
    }

    public void switchSkillBook()
    {
        curr_skill_index_ = 0;
        curr_book_index_ = (SkillSlotType)Utility.modNumber((int)curr_book_index_, BOOK_SIZE, 1);
        skill_equipment_scroll_ui_.moveLeft();
    }

    public void switchSkill(int _idx)
    {
        curr_skill_index_ = _idx;
    }

    public SkillBook getEquipmentBook(SkillSlotType _slot_type)
    {
        return skill_inventory_.getEquipmentBook(_slot_type);
    }

    public Skill getEquipmentSkill(int _slot_no, SkillSlotType _slot_type)
    {
        return skill_inventory_.getEquipmentSkill(_slot_no, _slot_type);
    }

    public Skill getCurrSkill()
    {
        return getEquipmentSkill(curr_skill_index_, curr_book_index_);
    }

    public KeyValuePair<SkillSlotType, int> searchSkillMaxLevel(int _no)
    {
        return skill_inventory_.searchSkillMaxLevel(_no);
    }

    public void swapSkillSlot(int _one_slot_no, SkillSlotType _one_slot_type, int _other_slot_on, SkillSlotType _other_slot_type)
    {
        skill_inventory_.swapSkillSlot(_one_slot_no, _one_slot_type, _other_slot_on, _other_slot_type);
    }

    public Skill getSkill(int _slot_no, SkillSlotType _slot_type)
    {
        return skill_inventory_.getSkill(_slot_no, _slot_type);
    }

    public void setSkill(Skill _skill, int _slot_no, SkillSlotType _slot_type)
    {
        skill_inventory_.setSkill(null, _slot_no, _slot_type);
    }

    public void createSkillBySlot(int _slot_no)
    {
        skill_inventory_.createSkill(_slot_no);
    }
}