using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UiAnimationController
{
    private static Animator main;
    private static Animator Camera;
    private static Animator Interact;
    private static GameObject insideCam;
    public static GameObject InteractObj;
    private static GameObject player;
    public static bool HasStarted;
    public static bool Playing;
    public static bool MainMenu;

    private static PlayerMovement _pm;
    private static PlayerMovement Pm { get => PmGet(); set => _pm = value; }

    private static MouseLook _ml;
    private static MouseLook Ml { get => MlGet(); set => _ml = value; }

    private static PlayerMovement PmGet()
    {
        if(_pm == null)
        {
            _pm = GameObject.Find("FirstPersonPlayer").GetComponent<PlayerMovement>();
        }

        return _pm;
    }

    private static MouseLook MlGet()
    {
        if(_ml == null)
        {
            _ml = GameObject.Find("Main Camera").GetComponent<MouseLook>();
        }

        return _ml;
    }

    public static void SetController(Animator _main) => main = _main;

    public static void SetCameraController(Animator _camera) => Camera = _camera;

    public static void SetInsideCamera(GameObject _Icam) => insideCam = _Icam;

    public static void SetPlayer(GameObject _player) => player = _player;

    public static void SetInteract(GameObject _interact)
    {
        InteractObj = _interact;

        Interact = Interact.GetComponent<Animator>();
    }

    public static bool Trigger(Triggers _trigger)
    {
        switch (_trigger)
        {
            case Triggers.ToMAIN:
                {
                    main.SetTrigger("ToMain");
                    Camera.SetTrigger("ToMain");
                    MainMenu = true;
                    Playing = false;
                    return true;
                }
            case Triggers.ToPLAY:
                {
                    UnLockMove();
                    main.SetTrigger("ToPlay");
                    Camera.SetTrigger("ToPlay");
                    UIManager.GetInstance().StartCoroutine(Wait());
                    MainMenu = false;
                    Playing = true;
                    return true;
                }
            case Triggers.ToSETTINGS:
                {
                    main.SetTrigger("ToSettings");
                    Playing = false;
                    return true;
                }
            case Triggers.ToOPTIONS:
                {
                    LockMove();
                    main.SetTrigger("ToOptions");
                    Playing = false;
                    return true;
                }
            case Triggers.ToSHOP:
                {
                    LockMove();
                    main.SetTrigger("ToShop");
                    Playing = false;
                    return true;
                }
            default:
                {
                    Application.Quit();
                    Debug.Log("krijg pest pleures");
                    Playing = false;
                    return false;
                }
        }
    }

    public static void Interactable(bool state)
    {
        if (Interact == null)
        {
            Interact = GameObject.Find("Interactsys").GetComponent<Animator>();
        }
        Interact.SetBool("Active", state);

    }

    private static IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        insideCam.SetActive(false);

    }

    public static void LockMove()
    {
        Ml.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Pm.enabled = false;
    }

    public static void UnLockMove()
    {
        Ml.enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Pm.enabled = true;
    }


}
