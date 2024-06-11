using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName ="ItemSystemItem")]
public class Item : ScriptableObject
{
    public int ItemID;
    public string ItemName;
    public Sprite ItemImage;

    public virtual void UseItem()
    { }

}
