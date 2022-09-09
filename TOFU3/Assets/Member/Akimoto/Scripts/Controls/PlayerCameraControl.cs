using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraControl : MonoBehaviour
{
    [SerializeField]
    private Camera playerCamera = null;

    private void Update()
    {
        AimAssistCheak();
    }

    // AimAssistCheak 関数
    public void AimAssistCheak()
    {
        RaycastHit hitObject = new RaycastHit();
        Ray        ray       = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f));
        
        if (Physics.SphereCast(ray, 2.0f, out hitObject))
        {
            Debug.Log(hitObject.transform.name);
            AimAssist(hitObject.transform.position - this.transform.position);
        }
    }
    // Camera の修正関数
    public void AimAssist(Vector2 enemyVec)
    {
        this.transform.Rotate(enemyVec);
    }
}