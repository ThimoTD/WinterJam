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
   

    void Update()
    {
        hitting = Physics.Raycast(lookDir.transform.position, lookDir.transform.forward, out hit);

        if (hitting)
        {
            if (hit.distance < 5 && hit.transform.tag == "Snowball" || hit.transform.tag == "Stone" || hit.transform.tag == "Stick" || hit.transform.tag == "Carrot" || hit.transform.tag == "Scarf" || hit.transform.tag == "Tophat" || hit.transform.tag == "Coin")
            {
                Debug.Log("press f to pickup noob man");
            }

            if (hit.distance < 5 && hit.transform.tag == "Snowball" && Input.GetKeyDown(KeyCode.E))
            {
                Destroy(hit.transform.gameObject);
                Inventory.snowballs++;
            }

            if (hit.distance < 5 && hit.transform.tag == "Stone" && Input.GetKeyDown(KeyCode.E))
            {
                Destroy(hit.transform.gameObject);
                Inventory.stones++;
            }

            if (hit.distance < 5 && hit.transform.tag == "Stick" && Input.GetKeyDown(KeyCode.E))
            {
                Destroy(hit.transform.gameObject);
                Inventory.sticks++;
            }

            if (hit.distance < 5 && hit.transform.tag == "Carrot" && Input.GetKeyDown(KeyCode.E))
            {
                Destroy(hit.transform.gameObject);
                Inventory.carrot++;
            }

            if (hit.distance < 5 && hit.transform.tag == "Scarf" && Input.GetKeyDown(KeyCode.E))
            {
                Destroy(hit.transform.gameObject);
                Inventory.scarf++;
            }

            if (hit.distance < 5 && hit.transform.tag == "Tophat" && Input.GetKeyDown(KeyCode.E))
            {
                Destroy(hit.transform.gameObject);
                Inventory.tophat++;
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
        }
    }
}