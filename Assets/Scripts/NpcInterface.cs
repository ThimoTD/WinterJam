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

    
    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            KeyCodePress.SetActive(true);
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
            KeyCodePress.SetActive(false);
            ShopInterface.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            ShopInterface.SetActive(true);
            texttt.SetActive(false);
            pm = GameObject.Find("FirstPersonPlayer").GetComponent<PlayerMovement>();
            pm.moveSpeed = 0;
            player.GetComponent<MouseLook>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Debug.Log("gtwge");
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ShopInterface.SetActive(false);
            pm = GameObject.Find("FirstPersonPlayer").GetComponent<PlayerMovement>();
            pm.moveSpeed = 10;
            player.GetComponent<MouseLook>().enabled = true;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Debug.Log("gtwge");
        }
    }

    public void DoubleJumpBuy()
    {
        if(Inventory.coins > 0)
        {

        }
    }

    public void DashBuy()
    {
        if (Inventory.coins > 0)
        {

        }
    }

    public void SprintBuy()
    {
        if (Inventory.coins > 0)
        {

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
