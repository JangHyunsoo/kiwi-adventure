using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBook : MonoBehaviour
{
    private static SkillBook _instance;
    public static SkillBook instance
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

    private SkillSlot[] have_skill_slots_;
    private SkillSlot[] equipment_skill_slots_;
    private SkillEquipSlot[] equipment_skill_icon_slots_;

    private int curr_skill_index = 0;
    private bool isFull = false;



    // Start is called before the first frame update
    void Start()
    {
        have_skill_slots_ = have_slot_parent_.GetComponentsInChildren<SkillSlot>();
        equipment_skill_slots_ = equipment_slot_parent_.GetComponentsInChildren<SkillSlot>();
        equipment_skill_icon_slots_ = equipment_icon_slot_parent_.GetComponentsInChildren<SkillEquipSlot>();
        AcquireItem(SkillDataBase.instance.getSkill(0));
        AcquireItem(SkillDataBase.instance.getSkill(1));
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

    public void AcquireItem(Skill _skill)
    {
        for (int i = 0; i < equipment_skill_slots_.Length; i++)
        {
            if (equipment_skill_slots_[i].skill == null)
            {
                equipment_skill_slots_[i].addSkill(_skill);
                updateEquipmentSlot();
                return;
            }
        }

        for (int i = 0; i < have_skill_slots_.Length; i++)
        {
            if (have_skill_slots_[i].skill == null)
            {
                have_skill_slots_[i].addSkill(_skill);
                return;
            }
        }
    }

    public Skill getCurrSkill()
    {
        return equipment_skill_slots_[curr_skill_index].skill;
    }

    public void updateEquipmentSlot()
    {
        for (int i = 0; i < equipment_skill_slots_.Length; i++)
        {
            if (equipment_skill_slots_[i].skill != null)
            {
                equipment_skill_icon_slots_[i].updateSlot(equipment_skill_slots_[i].skill);
            }
            else
            {
                equipment_skill_icon_slots_[i].clearSlot();
            }
        }
    }
}
