using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public List<GameObject> collectables;
    public List<Item> items;
    private Dictionary<GameObject,Item> itemsDic = new Dictionary<GameObject, Item>();

    void Awake()
    {
        for (int i = 0; i < items.Count; i++)
        {
            itemsDic.Add(collectables[i], items[i]);
        }

        foreach (GameObject collectable in collectables)
        {
            if (VariableManager.instance.HasItem(itemsDic[collectable]))
            {
                collectable.SetActive(false);
            }
        }
    }

}
