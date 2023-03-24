using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{

    public static InventoryManager Instance;

    public ScriptableWeapon[] weapons;
    public Text[] weaponsNames;
    public Image[] weaponsSprites;

    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(Instance);
    }

    public void AddWeapon(ScriptableWeapon weapon)
    {
        for(int i = 0; i < weapons.Length; i++)
        {
            if(weapons[i] == null)
            {
                weapons[i] = weapon;
                weaponsNames[i].text = weapon.weaponName;
                weaponsSprites[i].sprite = weapon.weaponSprite;

                return; 
            }
        }
    }
}
