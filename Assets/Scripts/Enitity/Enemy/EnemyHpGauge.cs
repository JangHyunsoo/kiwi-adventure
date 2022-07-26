using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyHpGauge : MonoBehaviour
{
    [SerializeField]
    private Text name_txt_;
    [SerializeField]
    private Image hp_gauge_image_;

    private float hp_amount_;

    private Transform hp_gauge_tr_;

    // Start is called before the first frame update
    void Start()
    {
        hp_gauge_tr_ = transform.GetChild(0);
        hp_amount_ = 1f;
        hp_gauge_image_.fillAmount = hp_amount_;
    }

    private void Update()
    {
        if (!EnemyManager.instance.isTargetEnemeyuEnmpty())
        {
            var enemys = EnemyManager.instance.getTargetEnemy();
            updateHpGauge(enemys[0].current_hp);
            if (!hp_gauge_tr_.gameObject.active)
            {
                hp_gauge_tr_.gameObject.SetActive(true);
            }
        }
        else
        {
            if (hp_gauge_tr_.gameObject.active)
            {
                hp_gauge_tr_.gameObject.SetActive(false);
            }
        }
    }

    public void updateHpGauge(float _amount)
    {
        if (_amount <= 0) _amount = 0;

        hp_amount_ = _amount;
        hp_gauge_image_.fillAmount = hp_amount_;
    }
}
