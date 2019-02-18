using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{

    public int playerNumber;

    public int selectedWeapon = 0;
    private float prevInput = 0, newInput;
    private string dpadString = "D-Pad_Axis_Gamepad";

    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon();
        dpadString += playerNumber;
    }

    // Update is called once per frame
    void Update()
    {

        newInput = Input.GetAxisRaw(dpadString);

        if(prevInput == 0)
        {
            if (Input.GetAxisRaw(dpadString) > 0f)
            {
                if (selectedWeapon >= transform.childCount - 1)
                    selectedWeapon = 0;
                else
                    selectedWeapon++;
            }
            if (Input.GetAxisRaw(dpadString) < 0f)
            {
                if (selectedWeapon <= 0)
                    selectedWeapon = transform.childCount - 1;
                else
                    selectedWeapon--;
            }

            SelectWeapon();
        }

        prevInput = newInput;
        
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
}

