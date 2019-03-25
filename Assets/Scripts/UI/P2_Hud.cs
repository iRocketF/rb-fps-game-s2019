using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class P2_Hud : MonoBehaviour
{
    public Image P2_HpBar;
    public Health P2_Hp;
    public PlayerMovement P2_PMov;
    public TextMeshProUGUI P2_Blinks;
    public Image P2_BlinkCd;
    public TextMeshProUGUI P2_Ammo;
    public WeaponAmmo P2_WpAmmo0;
    public WeaponAmmo P2_WpAmmo1;
    public WeaponAmmo P2_WpAmmo2;
    public WeaponSwitch P2_WpSwitch;
    public int P2_WpSel;
    public TextMeshProUGUI p2_WinText;
    public TextMeshProUGUI p2_HpText;

    public Image TakenDmg;
    public float dmgTimer;
    public float dmgTimerCD;
    public bool hasTakenDmg;
 


    // Start is called before the first frame update
    void Start()
    {
        P2_BlinkCd.fillAmount = 0;
        TakenDmg.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        Hitpoints();
        
        
        P2_Blinks.text = P2_PMov.currentBlinks.ToString();
        P2_BlinkCd.fillAmount = P2_PMov.nextBlinkTimer / P2_PMov.blinkCoolDown;
        WeaponGetter();
        WpAmmoText();

        //P2_Score.text = "P1: " + GameManager.instance.player1Score + " / P2: " + GameManager.instance.player2Score;
        P2_HpBar.color = Color.Lerp(Color.red, Color.green, P2_Hp.health / P2_Hp.maxhealth);
        WinnerText();

        if(hasTakenDmg)
        {
            TakenDmg.enabled = true;
            dmgTimer += Time.deltaTime;
            if(dmgTimer > dmgTimerCD)
            {
                TakenDmg.enabled = false;
                hasTakenDmg = false;
                dmgTimer = 0f;
            }
                
        }
    }

    void WeaponGetter()
    {
        P2_WpSel = P2_WpSwitch.selectedWeapon;
    }

    void WpAmmoText()
    {
        if (P2_WpSel == 0)
        {
            P2_Ammo.text = P2_WpAmmo0.currentAmmo + " / " + P2_WpAmmo0.maxAmmo;
        }
        else if (P2_WpSel == 1)
        {
            P2_Ammo.text = P2_WpAmmo1.currentAmmo + " / " + P2_WpAmmo1.maxAmmo;
        }
        else if (P2_WpSel == 2)
        {
            P2_Ammo.text = P2_WpAmmo2.currentAmmo + " / " + P2_WpAmmo2.maxAmmo;
        }

    }
    public void WinnerText()
    {
        if (GameManager.instance.p2_win)
        {
            p2_WinText.text = "YOU WIN!";
        }
        else if (GameManager.instance.p2_win == false)
        {
            p2_WinText.text = " ";
        }
    }

    public void GotHit()
    {
        hasTakenDmg = true;
    }

    public void Hitpoints()
    {
        P2_HpBar.fillAmount = P2_Hp.health / P2_Hp.maxhealth;
        p2_HpText.text = P2_Hp.health + " / " + P2_Hp.maxhealth;
    }

}
