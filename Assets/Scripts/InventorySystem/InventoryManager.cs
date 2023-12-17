using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private const int MAX_SLOTS = 9;

    public static InventoryManager Instance;
    public InventorySlot[] inventorySlots;
    public GameObject inventoryItemPrefab;
    public GameObject notePrefab;

    private int selectedSlot = -1;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        ChangeSelectedSlot(0);
    }

    private void Update()
    {
        if (Input.inputString != null)
        {
            bool isNumber = int.TryParse(Input.inputString, out int number);
            if (isNumber && number > 0 && number <= MAX_SLOTS)
            {
                ChangeSelectedSlot(number-1);
            }
        }
    }

    void ChangeSelectedSlot(int newValue)
    {
        if (selectedSlot >= 0)
        {
            inventorySlots[selectedSlot].Deselect();
        }
        
        inventorySlots[newValue].Select();
        selectedSlot = newValue;
    }

    public int GetSelectedSlot()
    {
        return selectedSlot;
    }

    public bool AddItem(Item item)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot == null )
            {
                SpawnNewItem(item, slot);
                return true;
            }
        }
        return false;
    }

    void SpawnNewItem(Item item, InventorySlot slot)
    {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();

        PropertyItemManager.Instance.SetPropertyItem(newItemGo, item.type);
        inventoryItem.InitialiseItem(item);
    }

    public GameObject GetItem(int index)
    {
        Transform itemTransform = inventorySlots[index].transform;

        return itemTransform.childCount > 0 ? itemTransform.GetChild(0).gameObject : null;
    }

}
