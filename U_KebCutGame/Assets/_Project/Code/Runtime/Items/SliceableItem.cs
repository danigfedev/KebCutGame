using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;

public class SliceableItem : MonoBehaviour
{
    public float explosionForce = 1;
    public Material cutMaterial;

    private bool sliced = false;

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"On Collision Enter in {name}. Colliding object: {collision.collider.name}");

        if(collision.collider.tag != Taglist.KnifeBladeTag || sliced)
        {
            return;
        }


        sliced = true;

        
        //var cutPlane= new EzySlice.Plane(transform.position, transform.up);

        float knifeWidth = collision.collider.bounds.size.x;

        GameObject[] fragments = SliceObject();
        
        //0: upper hull (cutting plane's normal direction)
        //1: lower hull
        for(int i = 0; i < fragments.Length; i++)
        {
            Vector3 explosionDirection = (i % 2 == 0) ? Vector3.right : Vector3.left;

            Debug.Log($"Fragment with index {i}: {fragments[i].name}");

            //Debug.Log($"Me cago en dios {transform.localPosition}");
            fragments[i].transform.position = transform.position + explosionDirection* knifeWidth;
            fragments[i].AddComponent<BoxCollider>();
            Rigidbody rb = fragments[i].AddComponent<Rigidbody>();
            rb.AddForce(explosionForce * explosionDirection);

        }

        gameObject.SetActive(false);
    }


    private GameObject[] SliceObject()
    {
        var cutPlane = new EzySlice.Plane(transform.position, Vector3.right);
        //GameObject[] fragments = gameObject.SliceInstantiate(cutPlane);
        return gameObject.SliceInstantiate(transform.position, Vector3.right, cutMaterial);
    }


    private void DebugVisualPlane()
    {
        var visiblePlane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        visiblePlane.transform.position = transform.position;
        visiblePlane.transform.up = transform.up;
    }
}
 