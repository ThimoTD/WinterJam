using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{

    //if close enough and looking at item show  "press f to pickup" 
    //if pressed f it pickups and disapears.

    public Camera lookDir;

    private RaycastHit hit;

    private bool hitting;

    private int itemsHolding;

    public GameObject door;

    public Animator anim;

    public GameObject PickUpText;
   

    void Update()
    {
        hitting = Physics.Raycast(lookDir.transform.position, lookDir.transform.forward, out hit);


        if (hitting)
        {
            if (hit.distance < 5 && hit.transform.tag == "Snowball" || hit.distance < 5 && hit.transform.tag == "Stone" || hit.distance < 5 && hit.transform.tag == "Stick" || hit.distance < 5 && hit.transform.tag == "Carrot" || hit.distance < 5 && hit.transform.tag == "Scarf" || hit.distance < 5 && hit.transform.tag == "Tophat" || hit.distance < 5 && hit.transform.tag == "Coin" || hit.distance < 5 && hit.transform.tag == "Key")
            {
                if (UiAnimationController.Playing)
                {
                    UiAnimationController.Interactable(true);
                }
                    
            }else
            {
                if (UiAnimationController.Playing)
                {
                    UiAnimationController.Interactable(false);
                }
                    
            }

            if (hit.distance < 5 && hit.transform.tag == "Snowball" && Input.GetKeyDown(KeyCode.E))
            {
                Destroy(hit.transform.gameObject);
                Inventory.snowballs++;
                Inventory.snowballsCount++;
            }

            if (hit.distance < 5 && hit.transform.tag == "Stone" && Input.GetKeyDown(KeyCode.E))
            {
                Destroy(hit.transform.gameObject);
                Inventory.stones++;
                Inventory.stonesCount++;
            }

            if (hit.distance < 5 && hit.transform.tag == "Stick" && Input.GetKeyDown(KeyCode.E))
            {
                Destroy(hit.transform.gameObject);
                Inventory.sticks++;
                Inventory.sticksCount++;
            }

            if (hit.distance < 5 && hit.transform.tag == "Carrot" && Input.GetKeyDown(KeyCode.E))
            {
                Destroy(hit.transform.gameObject);
                Inventory.carrot++;
                Inventory.carrotCount++;
            }

            if (hit.distance < 5 && hit.transform.tag == "Scarf" && Input.GetKeyDown(KeyCode.E))
            {
                Destroy(hit.transform.gameObject);
                Inventory.scarf++;
                Inventory.scarfCount++;
            }

            if (hit.distance < 5 && hit.transform.tag == "Tophat" && Input.GetKeyDown(KeyCode.E))
            {
                Destroy(hit.transform.gameObject);
                Inventory.tophat++;
                Inventory.tophatCount++;
            }

            if (hit.distance < 5 && hit.transform.tag == "Coin" && Input.GetKeyDown(KeyCode.E))
            {
                Destroy(hit.transform.gameObject);
                Inventory.coins++;
            }
            if (hit.distance < 5 && hit.transform.tag == "Key" && Input.GetKeyDown(KeyCode.E))
            {
                Destroy(hit.transform.gameObject);
                Inventory.key++;
            }
            if (hit.distance < 5 && hit.transform.tag == "Door" && Input.GetKeyDown(KeyCode.E) && Inventory.key > 0)
            {
                anim.SetBool("openDoor", true);
                Debug.Log("test");
            }

            if(hit.distance < 5 && hit.transform.tag == "ThrowableSnowball" && Input.GetKeyDown(KeyCode.K) && Inventory.trowableSnowball > 0)
            {

            }
        }
    }
}
