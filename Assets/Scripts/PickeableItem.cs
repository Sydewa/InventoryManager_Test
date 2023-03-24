using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickeableItem : MonoBehaviour
{
    public ScriptableWeapon weapon;

    private void Start() 
    {
        SpriteRenderer _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = weapon.weaponSprite;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            InventoryManager.Instance.AddWeapon(weapon);
            Destroy(this.gameObject);
        }
    }


}
