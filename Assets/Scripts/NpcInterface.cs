using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcInterface : MonoBehaviour
{
    public GameObject ShopInterface;
    public GameObject KeyCodePress;

    public GameObject texttt;

    public GameObject player;
    MouseLook mouselook;
    PlayerMovement pm;


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (UiAnimationController.Playing)
                UiAnimationController.Interactable(true);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Debug.Log("gtwge");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("call");
            UiAnimationController.Interactable(false);
            UiAnimationController.Trigger(Triggers.ToPLAY);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            UiAnimationController.Trigger(Triggers.ToSHOP);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UiAnimationController.Trigger(Triggers.ToPLAY);
        }
    }

    public void DoubleJumpBuy()
    {
        if(Inventory.coins > 0)
        {
            player.GetComponent<PlayerMovement>().maxJumps = 1;
        }
    }

    public void DashBuy()
    {
        if (Inventory.coins > 0)
        {
            player.GetComponent<PlayerMovement>().dashb = true;
        }
    }

    public void SprintBuy()
    {
        Debug.Log("SprintBuy");
        if (Inventory.coins > 0)
        {
            player.GetComponent<PlayerMovement>().moveSpeed = 20;
        }
    }

    public void TophatBuy()
    {
        if (Inventory.coins > 0 && Inventory.tophat == 0)
        {
            Inventory.tophat++;
            Inventory.tophatCount++;
            Inventory.coins --;
            Debug.Log(Inventory.coins);
        }
    }
}
