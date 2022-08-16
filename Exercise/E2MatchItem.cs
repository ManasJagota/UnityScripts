using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class E2MatchItem : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IDragHandler, IPointerEnterHandler
{
    
    static E2MatchItem hoverItem;

    public GameObject linePrefab;
    public string itemName;

    private GameObject line;

    public void OnPointerDown(PointerEventData eventData)
    {
        line = Instantiate(linePrefab, transform.position, Quaternion.identity, transform.parent);
        UpdateLine(eventData.position);
    }

    public void OnDrag(PointerEventData eventData)
    {
        UpdateLine(eventData.position);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if(!this.Equals(hoverItem) && itemName.Equals(hoverItem.itemName))
        {
            E2ScoreManager.instance.score++;
            UpdateLine(hoverItem.transform.position);
            Destroy(hoverItem);
            Destroy(this);
          
        }
        else
        {
            Destroy(line);
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        hoverItem = this;
    }

    void UpdateLine(Vector3 position)
    {
        Vector3 direction = position - transform.position;
        line.transform.right = direction;

        line.transform.localScale = new Vector3(direction.magnitude, 1, 1);
    }

}
