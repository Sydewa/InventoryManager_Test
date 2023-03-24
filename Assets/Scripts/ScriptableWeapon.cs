using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Items/NewWeapon")]
public class ScriptableWeapon : ScriptableObject 
{
    public string weaponName;
    public string weaponDescription;
    public Sprite weaponSprite;
    public float waponDamage;
}

