using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class popUpscript : MonoBehaviour, IPointerClickHandler
{
    public GameObject pinball;
 
    public void OnPointerClick(PointerEventData eventData)
    {
        pinball.SetActive(true);
        this.gameObject.SetActive(false);

    }
}
