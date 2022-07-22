using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpGauge : MonoBehaviour
{
    [SerializeField]
    private Image hp_gauge_image_;
    private float hp_amount_;

    void Start()
    {
        hp_amount_ = 1f;
        hp_gauge_image_.fillAmount = hp_amount_;
    }

    void Update()
    {
        updateHpGauge(PlayerManager.instance.player.getHpPersent());
    }

    public void updateHpGauge(float _amount)
    {
        if (_amount <= 0) _amount = 0;

        hp_amount_ = _amount;
        hp_gauge_image_.fillAmount = hp_amount_;
    }
}