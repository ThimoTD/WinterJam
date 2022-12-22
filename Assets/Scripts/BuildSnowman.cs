using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuildSnowman : MonoBehaviour
{
    public Camera lookDir;

    bool hasBuild = false;
    private RaycastHit hit;

    private bool hitting;
    bool snowmanFase1 = false;
    bool snowmanFase2 = false;
    bool snowmanFase3 = false;
    int snowmanCount;

    int arms;
    int stoneBody;
    int stoneHead;
    bool carrot;
    bool tophat;
    bool scarf;

    

    //Top part
    public GameObject topSnowmanFase1Part;
    public GameObject topSnowmanFase1;
    public GameObject topSnowmanFase2Part;
    public GameObject topSnowmanFase2;
    public GameObject topSnowmanFase3Part;
    public GameObject topSnowmanFase3;

    public GameObject StoneEyeLeft;
    public GameObject StoneEyeLeftPart;
    public GameObject StoneEyeRight;
    public GameObject StoneEyeRightPart;

    public GameObject carrotNose;
    public GameObject carrotNosePart;

    public GameObject StoneMouth1;
    public GameObject StoneMouth1Part;
    public GameObject StoneMouth2;
    public GameObject StoneMouth2Part;
    public GameObject StoneMouth3;
    public GameObject StoneMouth3Part;
    public GameObject StoneMouth4;
    public GameObject StoneMouth4Part;
    public GameObject StoneMouth5;
    public GameObject StoneMouth5Part;

    public GameObject Scarf;
    public GameObject ScarfPart;
    public GameObject Tophat;
    public GameObject TophatPart;

    //Middle part
    public GameObject middleSnowmanFase1Part;
    public GameObject middleSnowmanFase1;
    public GameObject middleSnowmanFase2Part;
    public GameObject middleSnowmanFase2;
    public GameObject middleSnowmanFase3Part;
    public GameObject middleSnowmanFase3;

    public GameObject LeftArm;
    public GameObject LeftArmPart;
    public GameObject RightArm;
    public GameObject RightArmPart;

    public GameObject StoneButton1;
    public GameObject StoneButton1Part;
    public GameObject StoneButton2;
    public GameObject StoneButton2Part;
    public GameObject StoneButton3;
    public GameObject StoneButton3Part;

    //Bottom part
    public GameObject bottomSnowmanFase1Part;
    public GameObject bottomSnowmanFase1;
    public GameObject bottomSnowmanFase2Part;
    public GameObject bottomSnowmanFase2;
    public GameObject bottomSnowmanFase3Part;
    public GameObject bottomSnowmanFase3;
    public GameObject BuildSnowManText;
    public GameObject VictoryText;
    public GameObject VictoryButton;

    public GameObject player;
    PlayerMovement pm;

    private bool Bruh = true;
    // Update is called once per frame

    public void resetScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    void Update()
    {
        if (arms == 2 && stoneBody == 3 && stoneHead == 7 && carrot  && tophat && scarf)
        {
            VictoryText.SetActive(true);
            VictoryButton.SetActive(true);
            pm = GameObject.Find("FirstPersonPlayer").GetComponent<PlayerMovement>();
            pm.moveSpeed = 0;
            player.GetComponent<MouseLook>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        hitting = Physics.Raycast(lookDir.transform.position, lookDir.transform.forward, out hit);
        if (hitting)
        {
            if (hit.distance < 5 && hit.transform.tag == "Snowman")
            {
                Debug.Log("Press f to build snowman man");
            }

            if (hit.distance < 5 && hit.transform.tag == "Snowman" && Input.GetKeyDown(KeyCode.E))
            {
                if (!snowmanFase1 && !snowmanFase2 && !snowmanFase3 && Inventory.snowballs > 0 && !hasBuild) // if snowman has nothing completely build yet
                {
                    if (snowmanCount == 0)
                    {
                        Inventory.snowballs--;
                        bottomSnowmanFase1Part.SetActive(false);
                        bottomSnowmanFase1.SetActive(true);
                        bottomSnowmanFase2Part.SetActive(true);

                        //unhide fase 1
                    }
                    else if (snowmanCount == 1)
                    {
                        Inventory.snowballs--;
                        bottomSnowmanFase2Part.SetActive(false);
                        bottomSnowmanFase1.SetActive(false);
                        bottomSnowmanFase2.SetActive(true);
                        bottomSnowmanFase3Part.SetActive(true);
                    }
                    else if (snowmanCount == 2)
                    {
                        Inventory.snowballs--;
                        bottomSnowmanFase2.SetActive(false);
                        bottomSnowmanFase3Part.SetActive(false);
                        bottomSnowmanFase3.SetActive(true);
                        middleSnowmanFase1Part.SetActive(true);
                        snowmanFase1 = true;
                        snowmanCount = -1;
                    }
                    snowmanCount++;
                    hasBuild = true;
                }

                if (snowmanFase1 && !snowmanFase2 && !snowmanFase3 && Inventory.snowballs > 0 && !hasBuild) // if snowman has only his legs build yet
                {
                    if (snowmanCount == 0)
                    {
                        Inventory.snowballs--;
                        middleSnowmanFase1Part.SetActive(false);
                        middleSnowmanFase1.SetActive(true);
                        middleSnowmanFase2Part.SetActive(true);
                    }
                    else if (snowmanCount == 1)
                    {
                        Inventory.snowballs--;
                        middleSnowmanFase1.SetActive(false);
                        middleSnowmanFase2Part.SetActive(false);
                        middleSnowmanFase2.SetActive(true);
                        middleSnowmanFase3Part.SetActive(true);
                    }
                    else if (snowmanCount == 2)
                    {
                        Inventory.snowballs--;
                        middleSnowmanFase2.SetActive(false);
                        middleSnowmanFase3Part.SetActive(false);
                        middleSnowmanFase3.SetActive(true);
                        topSnowmanFase1Part.SetActive(true);
                        LeftArmPart.SetActive(true);
                        StoneButton1Part.SetActive(true);
                        snowmanFase2 = true;
                        snowmanCount = -1;
                    }
                    snowmanCount++;
                    hasBuild = true;
                }

                if (snowmanFase1 && snowmanFase2 && !snowmanFase3 && Inventory.snowballs > 0 && !hasBuild) // if snowman has legs and body build
                {
                    if (snowmanCount == 0)
                    {
                        Inventory.snowballs--;
                        topSnowmanFase1Part.SetActive(false);
                        topSnowmanFase1.SetActive(true);
                        topSnowmanFase2Part.SetActive(true);
                    }
                    else if (snowmanCount == 1)
                    {
                        Inventory.snowballs--;
                        topSnowmanFase1.SetActive(false);
                        topSnowmanFase2Part.SetActive(false);
                        topSnowmanFase2.SetActive(true);
                        topSnowmanFase3Part.SetActive(true);
                    }
                    else if (snowmanCount == 2)
                    {
                        Inventory.snowballs--;
                        topSnowmanFase2.SetActive(false);
                        topSnowmanFase3Part.SetActive(false);
                        topSnowmanFase3.SetActive(true);
                        snowmanFase3 = true;
                        carrotNosePart.SetActive(true);
                        ScarfPart.SetActive(true);
                        TophatPart.SetActive(true);
                    }
                    snowmanCount++;
                    hasBuild = true;
                }

                if (snowmanFase1 && snowmanFase2 && !hasBuild) // if snowman has legs and body build
                {
                    if (Inventory.stones > 0 && stoneBody != 3 && !hasBuild)
                    {
                        if (stoneBody == 0)
                        {
                            Inventory.stones--;
                            StoneButton1.SetActive(true);
                            StoneButton1Part.SetActive(false);
                            StoneButton2Part.SetActive(true);
                        }
                        else if (stoneBody == 1)
                        {
                            Inventory.stones--;
                            StoneButton2.SetActive(true);
                            StoneButton2Part.SetActive(false);
                            StoneButton3Part.SetActive(true);
                        }
                        else if (stoneBody == 2)
                        {
                            Inventory.stones--;
                            StoneButton3.SetActive(true);
                            StoneButton3Part.SetActive(false);
                        }
                        hasBuild = true;
                        stoneBody++;
                    }

                    if (Inventory.sticks > 0 && arms != 2 && !hasBuild)
                    {
                        if (arms == 0)
                        {
                            Inventory.sticks--;
                            LeftArmPart.SetActive(false);
                            RightArmPart.SetActive(true);
                            RightArm.SetActive(true);
                        }
                        else if (arms == 1)
                        {
                            Inventory.sticks--;
                            RightArmPart.SetActive(false);
                            LeftArm.SetActive(true);
                        }
                        //unhide arms [arms] using array
                        hasBuild = true;
                        arms++;
                    }
                }

                if (snowmanFase1 && snowmanFase2 && snowmanFase3 && !hasBuild) // if snowman is completely build
                {
                    if (!carrot && !hasBuild && Inventory.carrot > 0)
                    {
                        carrotNose.SetActive(true);
                        carrotNosePart.SetActive(false);
                        hasBuild = true;
                        Inventory.carrot--;
                        carrot = true;
                    }
                    else if (Inventory.stones > 0 && !hasBuild && stoneHead != 7)
                    {
                        Debug.Log(hasBuild);
                        if (stoneHead == 0)
                        {
                            Inventory.stones--;
                            StoneEyeLeftPart.SetActive(false);
                            StoneEyeLeft.SetActive(true);
                            StoneEyeRightPart.SetActive(true);
                        }
                        else if (stoneHead == 1)
                        {
                            Inventory.stones--;
                            StoneEyeRightPart.SetActive(false);
                            StoneEyeRight.SetActive(true);
                            StoneMouth1Part.SetActive(true);
                        }
                        else if (stoneHead == 2)
                        {
                            Inventory.stones--;
                            StoneMouth1.SetActive(true);
                            StoneMouth1Part.SetActive(false);
                            StoneMouth2Part.SetActive(true);
                        }
                        else if (stoneHead == 3)
                        {
                            Inventory.stones--;
                            StoneMouth2.SetActive(true);
                            StoneMouth2Part.SetActive(false);
                            StoneMouth3Part.SetActive(true);
                        }
                        else if (stoneHead == 4)
                        {
                            Inventory.stones--;
                            StoneMouth3.SetActive(true);
                            StoneMouth3Part.SetActive(false);
                            StoneMouth4Part.SetActive(true);
                        }
                        else if (stoneHead == 5)
                        {
                            Inventory.stones--;
                            StoneMouth4.SetActive(true);
                            StoneMouth4Part.SetActive(false);
                            StoneMouth5Part.SetActive(true);
                        }
                        else if (stoneHead == 6)
                        {
                            Inventory.stones--;
                            StoneMouth5.SetActive(true);
                            StoneMouth5Part.SetActive(false);
                        }
                        hasBuild = true;
                        stoneHead++;
                    }
                    else if (!tophat && !hasBuild && Inventory.tophat > 0)
                    {
                        TophatPart.SetActive(false);
                        Tophat.SetActive(true);
                        Inventory.tophat--;
                        hasBuild = true;
                        tophat = true;
                    }
                    else if (!scarf && !hasBuild && Inventory.scarf > 0)
                    {
                        ScarfPart.SetActive(false);
                        Scarf.SetActive(true);
                        Inventory.scarf--;
                        hasBuild = true;
                        scarf = true;
                    }
                }

                if (stoneBody == 3 && snowmanFase3 && Bruh)
                {
                    Bruh = false;
                    StoneEyeLeftPart.SetActive(true);
                }
                hasBuild = false;

                
            }
        }
    }

    void Awake()
    {
        Inventory.snowballs = 9;
        Inventory.stones = 10;
        Inventory.carrot = 1;
        Inventory.scarf = 1;
        Inventory.sticks = 2;
        Inventory.tophat = 1;
        Inventory.coins = 0;
        Inventory.key = 0;

        Inventory.snowballsCount = 0;
        Inventory.stonesCount = 0;
        Inventory.carrotCount = 0;
        Inventory.scarfCount = 0;
        Inventory.tophatCount = 0;
        Inventory.sticksCount = 0;
    }
}
