using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPositionControl : MonoBehaviour
{
    private RaycastHit hitObject;
    // Start is called before the first frame update
    void Start()
    {
        ItemPositionChake();
        Debug.Log(hitObject.collider.gameObject.name);
    }

    private void ItemPositionChake()
    {
        Ray ray = new Ray(this.transform.position, this.transform.up);
        if(Physics.Raycast(ray,out hitObject))
            if (hitObject.collider.gameObject.tag == "GameObject")
                this.gameObject.transform.Translate(0,0,hitObject.transform.localScale.y/2 + 0.5f);
    }
}
