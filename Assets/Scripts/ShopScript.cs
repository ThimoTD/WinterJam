using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    public void TophatBuy()
    {
        if (Inventory.coins > 4 && Inventory.tophat == 0)
        {
            Inventory.tophat++;
        }
    }
}
