using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName ="ItemSystemItem")]
public class Item : ScriptableObject
{
    public int ItemID;
    public string ItmeName;
    public Sprite ItemImage;

    public virtual void UseItem()
    { }

}
