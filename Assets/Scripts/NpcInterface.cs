using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcInterface : MonoBehaviour
{
    public GameObject ShopInterface;
    public GameObject KeyCodePress;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTrigger(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            ShopInterface.SetActive(true);
            Debug.Log("gtwge");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            KeyCodePress.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            KeyCodePress.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            ShopInterface.SetActive(true);
            Debug.Log("gtwge");
        }
    }

}
