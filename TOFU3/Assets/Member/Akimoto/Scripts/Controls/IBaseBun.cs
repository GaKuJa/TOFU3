using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IBaseBun
{
    // 弾生成用関数
    List<Rigidbody> CreatBulletList();
    Vector3         BulletShotCalculation(Vector3 shotVec);
    void            BulletShot(Rigidbody bullet, Vector3 shotVec);
}
