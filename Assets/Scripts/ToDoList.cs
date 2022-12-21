using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ToDoList : MonoBehaviour
{
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    public TextMeshProUGUI text3;
    public TextMeshProUGUI text4;
    public TextMeshProUGUI text5;
    public TextMeshProUGUI text6;

    void Update()
    {
        text1.text = "Collect snowballs " + Inventory.snowballsCount + "/9";
        text2.text = "Collect stones " + Inventory.stonesCount + "/10";
        text3.text = "Collect carrots " + Inventory.carrotCount + "/1";
        text4.text = "Collect tophat " + Inventory.tophatCount + "/1";
        text5.text = "Collect scarf " + Inventory.scarfCount + "/1";
        text6.text = "Collect sticks " + Inventory.sticks + "/2";
    }
}
