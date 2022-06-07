using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchObject : MonoBehaviour
{
    [SerializeField]
    private float fov_ = 360f;
    [SerializeField]
    private int ray_count_ = 100;
    [SerializeField]
    private float view_distance_ = 4f;

    [SerializeField]
    private GameObject result_;

    private Vector3 origin;

    private void Update()
    {
        checkEnemy();
    }

    private void checkEnemy()
    {
        int ray_count = ray_count_;
        float angle = 0f;
        float view_distance = view_distance_;
        float angle_increase = fov_ / ray_count_;

        origin = transform.position;

        for (int i = 0; i <= ray_count_; i++)
        {
            RaycastHit2D raycast = Physics2D.Raycast(origin, Utility.GetVectorFromAngle(angle), view_distance_, (-1) - (1 << LayerMask.NameToLayer("Player")));

            Debug.Log("test");

            if (raycast.collider != null)
            {
                if (raycast.collider.gameObject.tag == Utility.MonsterTag)
                {
                    result_ = raycast.collider.gameObject;
                    Debug.Log(result_.name);
                }
                else
                {
                    Debug.Log(raycast.collider.gameObject.tag);
                }
            }
            else
            {
                Debug.Log("null");
            }

            angle -= angle_increase;
        }
    }
}
