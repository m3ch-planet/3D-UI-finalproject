﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    GameObject WaitRoomPanel;
    GameObject TurnPanel;
    GameObject PlayerTurnPanel;
    TextMeshProUGUI TurnText;
    TextMeshProUGUI TurnTimeText;
    GameObject UseItemBtn;
    GameObject WalkBtn;
    GameObject TeleportBtn;
    GameObject AttackBtn;
    GameObject EndTurnBtn;


    GameObject StartMenu;
    GameObject JoinMenu;
    GameObject HostMenu;

    GameObject MyProfile;

    private GameObject holdAttackText;
    private GameObject holdWalkText;
    

    [SerializeField]
    GameObject Background;
    [SerializeField]
    GameObject Menus;
    [SerializeField]
    GameObject Panels;
    private void Init()
    {
        Background.SetActive(true);
        Menus.SetActive(true);
        Panels.SetActive(true);

        // Locate corresponding GameObjects in the scene
        StartMenu = GameObject.Find("StartMenu");
        JoinMenu = GameObject.Find("JoinMenu");
        HostMenu = GameObject.Find("HostMenu");
        UseItemBtn = GameObject.Find("UseItem");
        WalkBtn = GameObject.Find("Walk");
        TeleportBtn = GameObject.Find("Teleport");
        AttackBtn = GameObject.Find("Attack"); 
        EndTurnBtn = GameObject.Find("End Turn");


        WaitRoomPanel = GameObject.Find("WaitRoomPanel");
        TurnPanel = GameObject.Find("TurnPanel");
        PlayerTurnPanel = GameObject.Find("PlayerTurnPanel");

        TurnText = TurnPanel.GetComponentsInChildren<TextMeshProUGUI>()[0];
        TurnTimeText = TurnPanel.GetComponentsInChildren<TextMeshProUGUI>()[1];
        
        MyProfile = GameObject.Find("MyProfile");
        
        

        // Set up event handlers
        GameObject.Find("My Profile").GetComponent<Button>().onClick.AddListener(() =>
        {
            EnableMyProfile(true);
            EnableStartMenu(false);
        });

        GameObject.Find("Join Game").GetComponent<Button>().onClick.AddListener(() =>
        {
            EnableJoinMenu(true);
            EnableStartMenu(false);
        });

        GameObject.Find("Host Game").GetComponent<Button>().onClick.AddListener(() =>
        {
            EnableHostMenu(true);
            EnableStartMenu(false);
        });

    }

    public void EnableTeleportBtn(bool active)
    {
        if (active)
        {
            TeleportBtn.SetActive(true);
            WalkBtn.SetActive(false);
            AttackBtn.SetActive(false);
            EndTurnBtn.SetActive(false);
        }
        else
        {
            TeleportBtn.SetActive(false);
            WalkBtn.SetActive(true);
            AttackBtn.SetActive(true);
            EndTurnBtn.SetActive(true);
        }
    }
    public void EnableUseItemBtn(bool active)
    {
        UseItemBtn.SetActive(active);
    }
    public void GoBack()
    {
        EnableHostMenu(false);
        EnableJoinMenu(false);
        EnableMyProfile(false);
        EnableStartMenu(true);
        EnableBackground(true);
    }

    private void Start()
    {
        Init();
        EnableStartMenu(true);

        // Menus disabled at start
        EnableMyProfile(false);
        EnableHostMenu(false);
        EnableJoinMenu(false);
        WaitRoomPanel.SetActive(false);
        TurnPanel.SetActive(false);
        EnableUseItemBtn(false);
        EnableTeleportBtn(false);
        PlayerTurnPanel.SetActive(false);
        
        holdAttackText = GameObject.Find("HoldAttackText");
        holdAttackText.SetActive(false);
        
        holdWalkText = GameObject.Find("HoldWalkText");
        holdWalkText.SetActive(false);
    }

    public void EnableStartMenu(bool active)
    {
        StartMenu.SetActive(active);
    }

    public void EnableBackground(bool active)
    {
        Background.SetActive(active);
    }

    public void EnableMyProfile(bool active)
    {
        MyProfile.SetActive(active);
    }

    public void EnableJoinMenu(bool active)
    {
        JoinMenu.SetActive(active);
    }

    public void EnableHostMenu(bool active)
    {
        HostMenu.SetActive(active);
    }

    public void SetWaitRoomPanel(bool active)
    {
        WaitRoomPanel.SetActive(active);
    }

    public void SetTurnPanel(bool active)
    {
        TurnPanel.SetActive(active);
    }

    public void SetTurnText(string s)
    {
        TurnText.text = s;
    }

    public void SetTurnTimeText(string s)
    {
        TurnTimeText.text = s;
    }

    public void SetPlayerTurnPanel(bool active)
    {
        PlayerTurnPanel.SetActive(active);
    }

    public void SetTurnTime(bool active)
    {
        TurnTimeText.gameObject.SetActive(active);
    }
}
