using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UiAnimationController
{
    private static Animator main;
    private static Animator Camera;
    public static bool HasStarted;
    public static bool Playing;
    public static bool MainMenu;

    public static void SetController(Animator _main) => main = _main;

    public static void SetCameraController(Animator _camera) => Camera = _camera;

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
                    main.SetTrigger("ToPlay");
                    Camera.SetTrigger("ToPlay");
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
                    main.SetTrigger("ToOptions");
                    Playing = false;
                    return true;
                }
            case Triggers.ToSHOP:
                {
                    main.SetTrigger("ToShop");
                    Playing = false;
                    return true;
                }
            default:
                {
                    Debug.Log("krijg pest pleures");
                    Playing = false;
                    return false;
                }
        }
    }
}
