using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBook : MonoBehaviour
{
    public static bool skill_book_activated = false;

    [SerializeField]
    private GameObject skill_book_go;
    [SerializeField]
    private GameObject slot_parent;

    private SkillSlot[] skill_slots;

    // Start is called before the first frame update
    void Start()
    {
        skill_slots = slot_parent.GetComponentsInChildren<SkillSlot>();
        AcquireItem(SkillDataBase.instance.getSkill(0));
        AcquireItem(SkillDataBase.instance.getSkill(1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenInventory()
    {
        skill_book_activated = true;
        skill_book_go.SetActive(true);
    }

    public void CloseInventory()
    {
        skill_book_activated = false;
        skill_book_go.SetActive(false);
    }

    public void AcquireItem(Skill _skill)
    {
        for(int i = 0; i < skill_slots.Length; i++)
        {
            if (skill_slots[i].skill == null)
            {
                skill_slots[i].addSkill(_skill);
                return;
            }
        }
    }
}
