﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class P1_Hud : MonoBehaviour
{
    public Image P1_HpBar;
    public Health P1_Hp;
    public PlayerMovement P1_PMov;
    public TextMeshProUGUI P1_Blinks;
    public Image P1_BlinkCd;
    public TextMeshProUGUI P1_Ammo;
    public WeaponAmmo P1_WpAmmo0;
    public WeaponAmmo P1_WpAmmo1;
    public WeaponAmmo P1_WpAmmo2;
    public WeaponSwitch P1_WpSwitch;
    public int P1_WpSel;
    public TextMeshProUGUI P1_Score;
    public Image crossHair;
    public TextMeshProUGUI p1_WinText;
    public TextMeshProUGUI P1_HpText;
    public Image TakenDmg;
    public Image P1_WinImg;



    // Start is called before the first frame update
    void Start()
    {
        P1_BlinkCd.fillAmount = 0;
        
    }

    // Update is called once per frame
    void Update()
    {

        Hitpoints();
        

        P1_Blinks.text = P1_PMov.currentBlinks.ToString();
        P1_BlinkCd.fillAmount = P1_PMov.nextBlinkTimer / P1_PMov.blinkCoolDown;
        WeaponGetter();
        WpAmmoText();

        P1_Score.text = GameManager.instance.player1Score + " / " + GameManager.instance.wins;
        P1_HpBar.color = Color.Lerp(Color.red, Color.green, P1_Hp.health / P1_Hp.maxhealth);
        WinnerText();

        if (P1_Hp.hasTakenDmg)
        {
            TakenDmg.enabled = true;
        }
        else
        {
            TakenDmg.enabled = false;
        }

    }

    void WeaponGetter()
    {
        P1_WpSel = P1_WpSwitch.selectedWeapon;
    }

    void WpAmmoText()
    {
        if (P1_WpSel == 0)
        {
            P1_Ammo.text = P1_WpAmmo0.currentAmmo + " / " + P1_WpAmmo0.maxAmmo;
        }
        else if (P1_WpSel == 1)
        {
            P1_Ammo.text = P1_WpAmmo1.currentAmmo + " / " + P1_WpAmmo1.maxAmmo;
        }
        else if (P1_WpSel == 2)
        {
            P1_Ammo.text = P1_WpAmmo2.currentAmmo + " / " + P1_WpAmmo2.maxAmmo;
        }

    }
    public void WinnerText()
    {
        if (GameManager.instance.p1_win)
        {
            P1_WinImg.enabled=true;
        }
        else if (GameManager.instance.p1_win == false)
        {
            P1_WinImg.enabled=false;
        }
    }

    public void Hitpoints()
    {
        P1_HpBar.fillAmount = P1_Hp.health / P1_Hp.maxhealth;
        P1_HpText.text = P1_Hp.health + " / " + P1_Hp.maxhealth;
    }

    /*
    public void hitMarked ()
    {
        hitM.enabled = true;
        Debug.Log(hitM);
    }
    */
}
