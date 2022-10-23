using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Food", menuName =
    "New Item/Food")]
public class FoodSO : ItemData
{
    private void Awake()
    {
        itemType = ItemType.Food;
    }
}
