using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Transactions;
using UnityEditor;
using TreeEditor;
using System.ComponentModel;

public class DrapDropScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [HideInInspector] [SerializeField] private Image image;
    [HideInInspector] [SerializeField] private RemovePlayer removePlayer;
    [HideInInspector] public Transform parentAfterDrag;
    [HideInInspector] public Transform parentBeforeDrag;
    [HideInInspector] public int _siblingIndex;

    private void Awake()
    {
        parentBeforeDrag = transform.parent; // I store the parent before me drag because I will need it later.
        _siblingIndex = transform.GetSiblingIndex(); // I am keeping the index of this object because I need this later.
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetParent(transform.root); // I am setting the object to a new parent.
        transform.SetAsLastSibling();// I am setting it to the last child of the parent
        image.raycastTarget = false; // I need to turn the raycast target off
        parentAfterDrag = null; // I then need to keep the parent after you have dragged to empty
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition; // I am moving the object based on the mouse position as I use the mouse to drag the player
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(parentAfterDrag != null)
        {
            transform.SetParent(parentAfterDrag); // After I have finished dragging I set the object to a new parent.
            image.raycastTarget = true; // I then re-enable the raycast target
        }
        else
        {
            removePlayer.OnRemovePlayer();// If there is an object already in the way I need to set it back to the last place.
        }
    }
}
