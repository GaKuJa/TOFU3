using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    [SerializeField]
    private Camera playerCamera = null;

    private Ray        bulletRay;
    private RaycastHit hitObject;
    public event Action     EventAcitonTest = new Action(() => { });

    private void Start()
    {
        bulletRay       =  new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        EventAcitonTest += BulletShot;
    }

    // 弾を飛ばす処理
    public void BulletShot()
    {
        if(Physics.Raycast(bulletRay,out hitObject))
            Debug.Log(hitObject);
    }
}
