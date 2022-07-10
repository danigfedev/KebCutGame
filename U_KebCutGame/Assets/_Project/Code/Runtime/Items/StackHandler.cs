using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackHandler : MonoBehaviour
{
    [SerializeField] private Transform item;
    [SerializeField] private float stackAmount = 1;

    private List<Transform> stackedItems = new List<Transform>();
    private float itemHeight;

    void Awake()
    {
        //Get item dimensions (idea: define a unique item height)
        itemHeight = item.GetComponent<Renderer>().bounds.size.y;
        Debug.Log($"Item height {itemHeight}");

        for (int i=0; i<stackAmount; i++)
        {
            Transform itemInstance = Instantiate(item);
            itemInstance.transform.position = transform.position + i * itemHeight * Vector3.up;
            itemInstance.transform.SetParent(transform);
            stackedItems.Add(itemInstance);
        }
    }

}
