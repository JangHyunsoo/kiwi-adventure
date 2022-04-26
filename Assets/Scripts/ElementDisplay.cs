using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementDisplay : MonoBehaviour
{
    [SerializeField]
    private Text air_element_text_;
    [SerializeField]
    private Text aqua_element_text_;
    [SerializeField]
    private Text earth_element_text_;
    [SerializeField]
    private Text fire_element_text_;
    [SerializeField]
    private Text photon_element_text_;
    [SerializeField]
    private Text element_dust_text_;

    public void updateElementDisplay()
    {
        air_element_text_.text = ItemInventory.instance.inventory[1].ToString();
        aqua_element_text_.text = ItemInventory.instance.inventory[2].ToString();
        earth_element_text_.text = ItemInventory.instance.inventory[3].ToString();
        fire_element_text_.text = ItemInventory.instance.inventory[4].ToString();
        photon_element_text_.text = ItemInventory.instance.inventory[5].ToString();
        element_dust_text_.text = ItemInventory.instance.inventory[6].ToString();
    }
}