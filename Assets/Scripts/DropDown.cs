﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
   
public class DropdownExample : MonoBehaviour
{
    [SerializeField] private TMP_Text numberText;

    public void DropdownSample(int index)
    {
        switch (index)
        {
            case 0: numberText.text = "1"; break;
            case 1: numberText.text = "2"; break;
            case 2: numberText.text = "3"; break;
        }
    }
}