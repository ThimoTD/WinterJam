using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSnowman : MonoBehaviour
{
    public Camera lookDir;

    public Inventory inventory;

    private RaycastHit hit;

    private bool hitting;

    bool snowmanFase1;
    int snowmanCount;

    bool snowmanFase2;

    bool snowmanFase3;

    int arms;

    int stoneBody;
    int stoneHead;

    bool carrot;
    bool tophat;
    bool scarf;


    // Update is called once per frame
    void Update()
    {
        hitting = Physics.Raycast(lookDir.transform.position, lookDir.transform.forward, out hit);

        if (hitting)
        {
            if(hit.distance < 5 && hit.transform.tag == "Snowman")
            {
                Debug.Log("Press f to build snowman man");
            }

            if(hit.distance < 5 && hit.transform.tag == "Snowman" && Input.GetKeyDown(KeyCode.F))
            {
                if (!snowmanFase1 && !snowmanFase2 && !snowmanFase3 && inventory.snowballs > 0) // if snowman has nothing completely build yet
                {
                    if (snowmanCount == 0)
                    {
                        inventory.snowballs--;
                        //unhide fase 1
                    } else if (snowmanCount == 1)
                    {
                        inventory.snowballs--;
                        //unhide fase 2
                        //hide fase 1
                    }
                    else if(snowmanCount == 2)
                    {
                        inventory.snowballs--;
                        //unhide fase 3;
                        //hide fase 2
                        snowmanFase1 = true;
                        snowmanCount = 0;
                    }
                    snowmanCount++;
                }

                if (snowmanFase1 && !snowmanFase2 && !snowmanFase3 && inventory.snowballs > 0) // if snowman has only his legs build yet
                {
                    if (snowmanCount == 0)
                    {
                        inventory.snowballs--;
                        //unhide fase 1
                    }
                    else if (snowmanCount == 1)
                    {
                        inventory.snowballs--;
                        //unhide fase 2
                        //hide fase 1
                    }
                    else if (snowmanCount == 2)
                    {
                        inventory.snowballs--;
                        //unhide fase 3;
                        //hide fase 2
                        snowmanFase2 = true;
                        snowmanCount = 0;
                    }
                    snowmanCount++;
                }

                if (snowmanFase1 && snowmanFase2 && !snowmanFase3 && inventory.snowballs > 0) // if snowman has legs and body build
                {
                    if (snowmanCount == 0)
                    {
                        inventory.snowballs--;
                        //unhide fase 1
                    }
                    else if (snowmanCount == 1)
                    {
                        inventory.snowballs--;
                        //unhide fase 2
                        //hide fase 1
                    }
                    else if (snowmanCount == 2)
                    {
                        inventory.snowballs--;
                        //unhide fase 3;
                        //hide fase 2
                        snowmanFase3 = true;
                        snowmanCount = 0;
                    }
                    snowmanCount++;
                }

                if(snowmanFase1 && snowmanFase2 && !snowmanFase3) // if snowman has legs and body build
                {

                }

                if (snowmanFase1 && snowmanFase2 && snowmanFase3) // if snowman is completely build
                {

                }

            }
        }
    }
}
