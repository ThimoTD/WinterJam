using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButton : MonoBehaviour
{
    public Triggers trigger;
    private Button btn;
    void Start()
    {
        btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(Trigger);
    }

    private void Trigger()
    {
        Debug.Log("click");
        UiAnimationController.Trigger(trigger);
    }
}
