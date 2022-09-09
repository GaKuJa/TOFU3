using UnityEngine;
public class GunScript : TOFUGUNScript
{

    private void Start()
    {
        //ShotCountNow = tofugun.GetShotCountNow();
        //ShotBullet = tofugun.GetShotBullet();
        TOFUGUNScript.Instance.ShotPrefab();
        TOFUGUNScript.Instance.ReloadBullet();
        TOFUGUNScript.Instance.PullMagazin();
        TOFUGUNScript.Instance.IntervalControl();
        TOFUGUNScript.Instance.GetMaxMagazinNum();
        TOFUGUNScript.Instance.GetMaxBulletNum();

    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {
            ShotPrefab();
        }

        if(Input.GetKey(KeyCode.R))
        {
            ReloadBullet();
        }
    }
}
