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
    private Image _hitmarker;


    // Start is called before the first frame update
    void Start()
    {
        Image[] array = gameObject.GetComponentsInChildren<Image>();
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i].tag.Contains("HitMarker"))
                _hitmarker = array[i];
        }
        Debug.Log(_hitmarker == null);
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

        _hitmarker.color = new Color(_hitmarker.color.r, _hitmarker.color.g, _hitmarker.color.b, Mathf.PingPong(Time.time, 1));
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
    /*  UNWORKENINGS
     * public void OnHitMarker()
    {
        if(_hitmarker == null)
        {
            Debug.Log("hitmarker is null");
            return;
        }
    
        _hitmarker.color = new Color(_hitmarker.color.r, _hitmarker.color.g, _hitmarker.color.b, 1);
        Invoke("HitMarkerDuration", 0.1f);
        
        
    }

    public void HitMarkerDuration()
    {
        Debug.Log("pls senpai");
        _hitmarker.color = new Color(_hitmarker.color.r, _hitmarker.color.g, _hitmarker.color.b, 0);
        Debug.Log("kawaii    " + _hitmarker.color.a );
    }*/
}
