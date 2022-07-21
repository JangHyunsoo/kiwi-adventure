using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillInventory : MonoBehaviour
{
    private static SkillInventory _instance;
    public static SkillInventory instance
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

    private bool skill_book_activated;

    [SerializeField]
    private GameObject skill_book_go_;
    [SerializeField]
    private GameObject have_slot_parent_;
    [SerializeField]
    private GameObject equipment_slot_parent_;
    [SerializeField]
    private GameObject equipment_icon_slot_parent_;

    [SerializeField]
    private SkillSlot[] have_skill_slots_;
    [SerializeField]
    private SkillSlot[] equipment_skill_slots_;

    [SerializeField]
    private SkillInfoCard skill_info_card_;

    [SerializeField]
    private SkillCastingDisplay skill_casting_display_;
    [SerializeField]
    private SkillSliderUI skill_slider_;
    public SkillSliderUI skill_slider { get => skill_slider_; }

    private int curr_skill_index_ = 0;
    public int curr_skill_index { get => curr_skill_index_; }

    public void init()
    {
        setupHaveSlot();
        setupEquipmentSlot();
        skill_casting_display_.init();
        AcquireSkillToHave(SkillDataBase.instance.getSkill(0, 0));
        AcquireSkillToHave(SkillDataBase.instance.getSkill(0, 0));
        AcquireSkillToHave(SkillDataBase.instance.getSkill(1, 0));
        AcquireSkillToEquipment(SkillDataBase.instance.getSkill(0, 1));
        updateCastingDisplay();
        updateEquipmentSlot();
    }

    private void setupHaveSlot()
    {
        have_skill_slots_ = have_slot_parent_.GetComponentsInChildren<SkillSlot>();
        for(int i = 0; i < have_skill_slots_.Length; i++)
        {
            have_skill_slots_[i].slot_no = i;
        }
    }

    private void setupEquipmentSlot()
    {
        equipment_skill_slots_ = equipment_slot_parent_.GetComponentsInChildren<SkillSlot>();
        for (int i = 0; i < equipment_skill_slots_.Length; i++)
        {
            equipment_skill_slots_[i].slot_no = i;
            equipment_skill_slots_[i].setupEquipmentSlot();
        }
    }
    public void OpenInventory()
    {
        skill_book_activated = true;
        skill_book_go_.SetActive(true);
    }

    public void CloseInventory()
    {
        skill_book_activated = false;
        skill_book_go_.SetActive(false);
    }

    public void AcquireSkillToHave(Skill _skill)
    {
        for (int i = 0; i < have_skill_slots_.Length; i++)
        {
            if (have_skill_slots_[i].skill == null)
            {
                have_skill_slots_[i].addSkill(_skill);
                return;
            }
        }
    }

    public void AcquireSkillToEquipment(Skill _skill)
    {
        for (int i = 0; i < equipment_skill_slots_.Length; i++)
        {
            if (equipment_skill_slots_[i].skill == null)
            {
                equipment_skill_slots_[i].addSkill(_skill);
                return;
            }
        }
    }

    public Skill getCurrSkill()
    {
        return equipment_skill_slots_[curr_skill_index_].skill;
    }

    public Skill getEquipmentSkill(int _idx)
    {
        return equipment_skill_slots_[_idx].skill;
    }

    public void updateEquipmentSlot()
    {
        skill_slider_.updateSkillImage();
    }

    public void updateCastingDisplay()
    {
        skill_casting_display_.updateNeed(getCurrSkill());
    }

    public void updateSkillInfoCard(SkillSlot _slot)
    {
        skill_info_card_.setSkill(_slot);
    }

    public void updateSkillSlot()
    {

        for (int i = 0; i < have_skill_slots_.Length; i++)
        {
            if (have_skill_slots_[i].skill != null)
            {
                have_skill_slots_[i].updateSkill();
            }
        }
    }

    public void createSkill()
    {
        SkillSlot curr_slot = skill_info_card_.curr_slot;
        Skill curr_skill = skill_info_card_.curr_slot.skill;

        if (!ItemInventory.instance.checkItems(curr_skill.skill_recipe_data.ToDictionary()))
        {
            Debug.Log("cannot create skill");
        }
        else
        {
            ItemInventory.instance.useItems(curr_skill.skill_recipe_data.ToDictionary());
            Skill max_skill = searchSkillMaxLevel(curr_skill.skill_data.skill_no);
            if(curr_skill == max_skill)
            {
                curr_skill.level++;
            }
            else
            {
                max_skill.level++;
                curr_slot.clearSlot();
            }
            updateSkillSlot();
            Debug.Log("create " + curr_skill.skill_data.skill_name);
        }
        skill_info_card_.updateSkillInfo();
    }

    private Skill searchSkillMaxLevel(int _no)
    {
        List<Skill> result = new List<Skill>();

        for (int i = 0; i < equipment_skill_slots_.Length; i++)
        {
            if (equipment_skill_slots_[i].skill != null)
            {
                if (equipment_skill_slots_[i].skill.skill_data.skill_no == _no)
                {
                    result.Add(equipment_skill_slots_[i].skill);
                }
            }
        }

        for (int i = 0; i < have_skill_slots_.Length; i++)
        {
            if (have_skill_slots_[i].skill != null)
            {
                if(have_skill_slots_[i].skill.skill_data.skill_no == _no)
                {
                    result.Add(have_skill_slots_[i].skill);
                }
            }
        }

        result.Sort(delegate (Skill one, Skill other) 
        {
            if (one.level < other.level) return 1;
            else if (one.level > other.level) return -1;
            else return 0;
        });

        return result[0];
    }

    public void sortSkill()
    {
        for (int i = 0; i < have_skill_slots_.Length; i++)
        {
            for (int j = 0; j < have_skill_slots_.Length; j++)
            {
                if (compareSkill(have_skill_slots_[i].skill, have_skill_slots_[j].skill) == 1)
                {
                    swapHaveSkillSlot(i, j);
                }
            }
        }
    }

    private int compareSkill(Skill one, Skill other)
    {
        if (one == null) return -1;
        else if (other == null) return 1;
        else if (one.level == other.level) return one.skill_data.skill_name.CompareTo(other.skill_data.skill_name);
        else return one.level.CompareTo(other.level);
    }

    // contain update
    private void swapHaveSkillSlot(int _idx1, int _idx2)
    {
        Skill skill1 = have_skill_slots_[_idx1].skill;
        Skill skill2 = have_skill_slots_[_idx2].skill;

        have_skill_slots_[_idx1].skill = skill2;
        have_skill_slots_[_idx2].skill = skill1;

        have_skill_slots_[_idx1].updateSkill();
        have_skill_slots_[_idx2].updateSkill();
    }   

    public void moveCurrSkillCursor(int _idx)
    {
        curr_skill_index_ = _idx;
        updateCastingDisplay();
    }

    public void clearCurrCasting()
    {
        skill_casting_display_.clearCurr();
    }

    public void updateCurrCasting(string _str)
    {
        skill_casting_display_.updateCurr(_str);
    }

}