using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject InsideCamera;
    public GameObject Interact;
    private List<GameObject> children = new();
    private static UIManager instance;
    public void Awake()
    {
        
        instance = this;
        UiAnimationController.SetController(gameObject.GetComponent<Animator>());
        UiAnimationController.SetCameraController(InsideCamera.GetComponent<Animator>());
        UiAnimationController.SetInsideCamera(InsideCamera);
      //  UiAnimationController.SetInteract(Interact);
        UiAnimationController.LockMove();

        foreach (Transform child in transform.GetComponentsInChildren<Transform>()) 
        {
            children.Add(child.gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(UiAnimationController.HasStarted != true)
            {
                UiAnimationController.HasStarted = true;
                UiAnimationController.Trigger(Triggers.ToMAIN);
                
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            children = new();
            foreach (Transform child in transform.GetComponentsInChildren<Transform>())
            {
                children.Add(child.gameObject);
            }



            Debug.Log("escape");
            foreach(GameObject child in children)
            {
                Debug.Log(child.name);
                if(child.active)
                {
                    if(child.name == "MainMenu")
                    {
                        Debug.Log("quit");
                        Quit();
                        break;
                    }

                    if (child.name == "playing")
                    {
                        Debug.Log("esq quit");
                        UiAnimationController.Trigger(Triggers.ToOPTIONS);
                        break;
                    }

                    if(child.name == "options")
                    {
                        Debug.Log("back to play");
                        UiAnimationController.Trigger(Triggers.ToPLAY);
                        break;
                    }

                    if (child.name == "Settings")
                    {
                        Debug.Log("esc in settings?");
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

    public static UIManager GetInstance()
    {
        return instance;
    }
}
