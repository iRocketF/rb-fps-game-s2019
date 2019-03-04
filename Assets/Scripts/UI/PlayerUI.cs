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

    }
}
