using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSliderUI : MonoBehaviour
{
    private readonly KeyCode[] skill_idx_ =
    {
        KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3,
        KeyCode.Alpha4, KeyCode.Alpha5
    };

    private float rotate_angle_;
    private Quaternion target_rotation_;
    private float speed_ = 5f;

    private const int SKILL_SIZE_ = 5;
    private const int SLOT_SIZE_ = 8;

    [SerializeField]
    private int front_slot_index_ = 0;
    [SerializeField]
    private int end_slot_index_ = 4;

    [SerializeField]
    private int cur_pos_index_ = 1;
    [SerializeField]
    private int cur_skill_index_ = 1;

    [SerializeField]
    private int[] real_idx_pos_ = { 0, 1, 2, 3, 4 };

    [SerializeField]
    private Transform skill_slot_image_parent_;

    [SerializeField]
    private Transform[] skill_slot_image_list_;

    [SerializeField]
    private Transform[] skill_slot_pos_list_;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            rotateNext();
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            rotatePrivious();
        }
        updateSkillSlotPos();
        updateScale();
        rotateCircle();
    }

    private void Start()
    {
        skill_slot_image_list_ = Utility.getChildsTransform(skill_slot_image_parent_);
        skill_slot_pos_list_ = Utility.getChildsTransform(transform);
        target_rotation_ = Quaternion.Euler(0, 0, 0);
        calculRotateAngle();
    }

    private void updateSkillSlotPos()
    {
        for (int i = 0; i < SKILL_SIZE_; i++)
        {
            skill_slot_image_list_[i].position = skill_slot_pos_list_[real_idx_pos_[i]].position;
        }
    }

    private void calculRotateAngle()
    {
        rotate_angle_ = 45 - (Mathf.Atan2(48f, 256f) / Mathf.PI * 180);
    }

    private void rotateCircle()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, target_rotation_, Time.deltaTime * speed_);
    }

    private void updateScale()
    {
        for (int i = 0; i < SKILL_SIZE_; i++)
        {
            var cur_image = skill_slot_image_list_[i];
            if (cur_skill_index_ == i)
            {
                cur_image.localScale = Vector3.Lerp(Vector3.one, cur_image.localScale, Time.deltaTime * speed_);
            }
            else
            {
                cur_image.localScale = Vector3.Lerp(Vector3.one * 0.75f, cur_image.localScale, Time.deltaTime * speed_);
            }
        }
    }

    private void rotateNext()
    {
        var new_front_idx = (front_slot_index_ - 1) % SKILL_SIZE_;
        if (new_front_idx < 0) new_front_idx += SKILL_SIZE_;

        if (cur_pos_index_ - real_idx_pos_[front_slot_index_] == 1) 
        {
            var new_front_real_pos = (real_idx_pos_[front_slot_index_] - 1) % SLOT_SIZE_;
            if (new_front_real_pos < 0) new_front_real_pos += SLOT_SIZE_;
            real_idx_pos_[new_front_idx] = new_front_real_pos;
            front_slot_index_ = new_front_idx;
            end_slot_index_ = (end_slot_index_ - 1) % SKILL_SIZE_;
            if (end_slot_index_ < 0)
            {
                end_slot_index_ += SKILL_SIZE_;
            }
        }
        else if (cur_pos_index_ == 0 && real_idx_pos_[front_slot_index_] == (SLOT_SIZE_ - 1))
        {
            real_idx_pos_[new_front_idx] = 6;
            front_slot_index_ = new_front_idx;
            end_slot_index_ = (end_slot_index_ - 1) % SKILL_SIZE_;
            if (end_slot_index_ < 0)
            {
                end_slot_index_ += SKILL_SIZE_;
            }
        }

        cur_pos_index_ = (cur_pos_index_ - 1) % SLOT_SIZE_;
        cur_skill_index_ = (cur_skill_index_ - 1) % SKILL_SIZE_;

        if (cur_pos_index_ < 0)
        {
            cur_pos_index_ += SLOT_SIZE_;
        }

        if (cur_skill_index_ < 0)
        {
            cur_skill_index_ += SKILL_SIZE_;
        }

        target_rotation_ = Quaternion.Euler(new Vector3(0, 0, target_rotation_.eulerAngles.z - 45));
    }

    private void rotatePrivious()
    {
        var new_end_idx = (end_slot_index_ + 1) % SKILL_SIZE_;

        if (cur_pos_index_ - real_idx_pos_[end_slot_index_] == -1)
        {
            var new_end_real_pos = (real_idx_pos_[end_slot_index_] + 1) % SLOT_SIZE_;
            real_idx_pos_[new_end_idx] = new_end_real_pos;
            end_slot_index_ = new_end_idx;
            front_slot_index_ = (front_slot_index_ + 1) % SKILL_SIZE_;
        }
        else if (cur_pos_index_ == (SLOT_SIZE_ - 1) && real_idx_pos_[end_slot_index_] == 0)
        {
            real_idx_pos_[new_end_idx] = 1;
            end_slot_index_ = new_end_idx;
            front_slot_index_ = (front_slot_index_ + 1) % SKILL_SIZE_;
        }

        cur_pos_index_ = (cur_pos_index_ + 1) % SLOT_SIZE_;
        cur_skill_index_ = (cur_skill_index_ + 1) % SKILL_SIZE_;

        target_rotation_ = Quaternion.Euler(new Vector3(0, 0, target_rotation_.eulerAngles.z + 45));
    }


 //   private void moveCurrSkillCursorWithKeyboard()
 //   {
 //       if (Input.anyKeyDown)
 //       {
 //           for (int i = 0; i < skill_idx_.Length; i++)
 //           {
 //               if (Input.GetKeyDown(skill_idx_[i]))
 //               {
 //                   changeSkill(i);
 //                   _isReload = false;
 //                   _command_idx = 0;
 //                   _isCasting = false;
 //               }
 //           }
 //       }
 //   }

}
