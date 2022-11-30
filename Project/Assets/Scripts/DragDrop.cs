using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Transform equipment;
    private Vector2 beforePos;
    private List<RaycastResult> _hits = new List<RaycastResult>();
    private bool isSave;
    private ItemHolder itemHolder;
    private Transform beforeParent;
    
    
    private void Awake()
    {
        
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        itemHolder = GetComponent<ItemHolder>();
        
        
        
  
    }

    private void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("Menu Canvas").GetComponent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin Drag");
        itemHolder.itemSlot.DefaultColor();
        beforePos = rectTransform.anchoredPosition;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = .7f;
        beforeParent = transform.parent;
        transform.SetParent(GameObject.FindGameObjectWithTag("Equipment").transform);

        if (itemHolder.itemSlot.isStorage)
        {
            StorageManager.instance.Leave(itemHolder);
        }
       
        
        
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(beforeParent);
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        var rayEventData = new PointerEventData(EventSystem.current) { position = Input.mousePosition };
        _hits.Clear();
        var graphicsRaycasters = FindObjectsOfType<GraphicRaycaster>();
        
        foreach (var graphicsRaycaster in graphicsRaycasters)
        {
            graphicsRaycaster.Raycast(eventData, _hits);
        }

        isSave = false;
        // Do something with the hits
        foreach (var result in _hits)
        {
            if (result.gameObject.CompareTag("Storage"))
            {
                
                //itemStats.itemSlot.Unequip();
                StorageManager.instance.Store(itemHolder);
                GlobalStats.instance.RecalulateStats();
                GlobalStats.instance.SaveCurrentItemsSO();
                isSave = true;

                break;
            }

            else if (result.gameObject.TryGetComponent(out ItemSlot itemSlot) == true )
            {
                if (itemSlot.CorrectSlot(itemHolder) && itemSlot.isStorage == false)
                {
                    
                    //itemStats.itemSlot.Unequip();
                    itemSlot.Equip(itemHolder);
                    isSave = true;
                    itemHolder.itemSlot.RecolorSlot();
                    GlobalStats.instance.RecalulateStats();
                    GlobalStats.instance.SaveCurrentItemsSO();
                    break;
                    
                } 
                
               
            }
            

        }

        if (isSave == false)
        {
            if (itemHolder.itemSlot == null)
            {
                StorageManager.instance.Store(itemHolder);
                GlobalStats.instance.SaveCurrentItemsSO();
            }
            else
            {
                itemHolder.itemSlot.RecolorSlot();
                rectTransform.anchoredPosition = beforePos;
            }
            
        }

        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    
}
