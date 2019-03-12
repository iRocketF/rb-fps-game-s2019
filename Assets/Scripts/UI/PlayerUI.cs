using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    public Image hpBar;
    public Health hp;
    public PlayerMovement pMov;
    public TextMeshProUGUI blinks;
    public Image blinkCD;
    public TextMeshProUGUI ammo;
    public WeaponAmmo wpAmmo0;
    public WeaponAmmo wpAmmo1;
    public WeaponAmmo wpAmmo2;
    public WeaponSwitch wpSwitch;
    public int weaponSelected;
    public TextMeshProUGUI score;


    // Start is called before the first frame update
    void Start()
    {
        blinkCD.fillAmount = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        hpBar.fillAmount = hp.health / hp.maxhealth;
        blinks.text = pMov.currentBlinks.ToString();
        blinkCD.fillAmount = pMov.nextBlinkTimer / pMov.blinkCoolDown;
        WeaponGetter();
        WpAmmoText();
        // ammo.text = wpAmmo.currentAmmo + " / " + wpAmmo.maxAmmo;
        score.text = "P1: " + GameManager.instance.player1Score + " / P2: " + GameManager.instance.player2Score;
        hpBar.color = Color.Lerp(Color.red, Color.green, hp.health / hp.maxhealth);
    }

    void WeaponGetter()
    {
        weaponSelected = wpSwitch.selectedWeapon;
    }
    void WpAmmoText()
    {
        if (weaponSelected == 0)
        {
            ammo.text = wpAmmo0.currentAmmo + " / " + wpAmmo0.maxAmmo;
        }
        else if (weaponSelected == 1)
        {
            ammo.text = wpAmmo1.currentAmmo + " / " + wpAmmo1.maxAmmo;
        }
        else if (weaponSelected == 2)
        {
            ammo.text = wpAmmo2.currentAmmo + " / " + wpAmmo2.maxAmmo;
        }

    }
}
