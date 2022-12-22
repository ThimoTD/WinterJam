using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject InsideCamera;

    private List<GameObject> children = new();
    public void Awake()
    {
        UiAnimationController.SetController(gameObject.GetComponent<Animator>());
        UiAnimationController.SetCameraController(InsideCamera.GetComponent<Animator>());

        foreach (Transform child in transform.GetComponentsInChildren<Transform>()) 
        {
            children.Add(child.gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UiAnimationController.HasStarted = true;
            UiAnimationController.Trigger(Triggers.ToMAIN);
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            foreach(GameObject child in children)
            {
                if(child.active)
                {
                    if(child.name == "MainMenu")
                    {
                        Quit();
                        break;
                    }

                    if (child.name == "Playing")
                    {
                        UiAnimationController.Trigger(Triggers.ToSETTINGS);
                        break;
                    }

                    if(child.name == "options")
                    {
                        UiAnimationController.Trigger(Triggers.ToPLAY);
                        break;
                    }

                    if (child.name == "Settings")
                    {
                        if (InsideCamera.active)
                        {
                            UiAnimationController.Trigger(Triggers.ToMAIN);
                        }
                        else
                        {
                            UiAnimationController.Trigger(Triggers.ToOPTIONS);
                        }
                        break;
                    }

                    if (child.name == "Shop")
                    {
                        UiAnimationController.Trigger(Triggers.ToPLAY);
                        break;
                    }

                }
            } 
        }
    }

    public void EixtSettings()
    {
        if (InsideCamera.active)
        {
            UiAnimationController.Trigger(Triggers.ToMAIN);
        }
        else
        {
            UiAnimationController.Trigger(Triggers.ToOPTIONS);
        }
    }

    



    public void Quit()
    {
        Application.Quit();
    }
}
