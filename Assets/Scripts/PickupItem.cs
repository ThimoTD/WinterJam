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

    public Inventory inventory;

    private int itemsHolding;
   

    void Update()
    {
        hitting = Physics.Raycast(lookDir.transform.position, lookDir.transform.forward, out hit);

        if (hitting)
        {
            if (hit.distance < 5 && hit.transform.tag == "Snowball" || hit.transform.tag == "Stone" || hit.transform.tag == "Stick" || hit.transform.tag == "Carrot" || hit.transform.tag == "Scarf" || hit.transform.tag == "Tophat" || hit.transform.tag == "Coin")
            {
                Debug.Log("press f to pickup noob man");
            }

            if (hit.distance < 5 && hit.transform.tag == "Snowball" && Input.GetKeyDown(KeyCode.F))
            {
                Destroy(hit.transform.gameObject);
                inventory.snowballs++;
            }

            if (hit.distance < 5 && hit.transform.tag == "Stone" && Input.GetKeyDown(KeyCode.F))
            {
                Destroy(hit.transform.gameObject);
                inventory.stones++;
            }

            if (hit.distance < 5 && hit.transform.tag == "Stick" && Input.GetKeyDown(KeyCode.F))
            {
                Destroy(hit.transform.gameObject);
                inventory.sticks++;
            }

            if (hit.distance < 5 && hit.transform.tag == "Carrot" && Input.GetKeyDown(KeyCode.F))
            {
                Destroy(hit.transform.gameObject);
                inventory.carrot++;
            }

            if (hit.distance < 5 && hit.transform.tag == "Scarf" && Input.GetKeyDown(KeyCode.F))
            {
                Destroy(hit.transform.gameObject);
                inventory.scarf++;
            }

            if (hit.distance < 5 && hit.transform.tag == "Tophat" && Input.GetKeyDown(KeyCode.F))
            {
                Destroy(hit.transform.gameObject);
                inventory.tophat++;
            }

            if (hit.distance < 5 && hit.transform.tag == "Coin" && Input.GetKeyDown(KeyCode.F))
            {
                Destroy(hit.transform.gameObject);
                inventory.coins++;
            }
        }
    }
}
