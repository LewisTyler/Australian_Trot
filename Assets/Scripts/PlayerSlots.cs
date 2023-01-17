using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class PlayerSlots : MonoBehaviour, IDropHandler
{
    // When you have dropped the object something needs to happen
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;// Giving me backed the current selected object
        DrapDropScript draggableItem = dropped.GetComponent<DrapDropScript>();

        if (transform.childCount == 0) // Looking to see if the object I want to drop on does not have any other childern
        {
            draggableItem.parentAfterDrag = transform; // Then I set this object to the new parent.
        }
    }
}
