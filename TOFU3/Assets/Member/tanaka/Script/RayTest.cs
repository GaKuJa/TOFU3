using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayTest : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            RaycastHit hit;
            if (Physics.Raycast(gameObject.transform.position, Vector3.up, out hit, 6.0f))
            {
                Destroy(hit.collider.gameObject);
            }
        }
    }
}
