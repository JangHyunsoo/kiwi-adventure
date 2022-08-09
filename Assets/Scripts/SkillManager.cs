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
    private SkillInfoCardUI skill_info_card_;
    [SerializeField]
    private SkillEquipmentScrollUI skill_equipment_scroll_ui_;
    [SerializeField]
    private SkillCommandUI skill_command_ui_;

    [SerializeField]
    private SkillInventory skill_inventory_;

    private int BOOK_SIZE = 3;

    private int curr_book_index_ = 0;
    private int curr_skill_index_ = 0;
    public int curr_skill_index { get => curr_skill_index_; }
    public int curr_book_index { get => curr_book_index_; }
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

    public void updateSkillInfoCard(int _slot_no, int _book_no)
    {
        skill_info_card_.setSlotNo(_slot_no, _book_no);
    }

    public void moveCurrSkillCursor(int _idx)
    {
        curr_skill_index_ = _idx;
    }

    public void switchSkillBook()
    {
        curr_skill_index_ = 0;
        curr_book_index_ = Utility.modNumber(curr_book_index_, BOOK_SIZE, 1);
        skill_equipment_scroll_ui_.moveLeft();
    }

    public void switchSkill(int _idx)
    {
        curr_skill_index_ = _idx;
    }

    public SkillBook getEquipmentBook(int _idx)
    {
        return skill_inventory_.getEquipmentBook(_idx);
    }

    public Skill getEquipmentSkill(int _slot_no, int _book_no)
    {
        return skill_inventory_.getEquipmentSkill(_slot_no, _book_no);
    }

    public Skill getCurrSkill()
    {
        return getEquipmentSkill(curr_skill_index_, curr_book_index_);
    }

    public Skill searchSkillMaxLevel(int _no)
    {
        return skill_inventory_.searchSkillMaxLevel(_no);
    }

    public void swapSkillSlot(SkillInventorySkillSlotUI _one, SkillInventorySkillSlotUI _other)
    {
        skill_inventory_.swapSkillSlot(_one, _other);
    }

    public Skill getSkill(int _slot_no, int _book_no)
    {
        return skill_inventory_.getSkill(_slot_no, _book_no);
    }

    public void setSkill(Skill _skill, int _slot_no, int _book_no)
    {
        skill_inventory_.setSkill(null, _slot_no, _book_no);
    }

    public void createSkillBySlot(int _slot_no, int _book_no)
    {
        skill_inventory_.createSkill(_slot_no, _book_no);
    }
}