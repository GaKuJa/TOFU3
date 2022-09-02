using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KATSUO : BaseGunStatus, IBaseBulletDamege
{
    public static KATSUO Instance { get => _instance; }
    static KATSUO _instance;
    [SerializeField]
    private GameObject Player;

    RaycastHit hitObj;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            hitObj = NaifAttack();

        }
    }

    private RaycastHit NaifAttack()
    {
        Ray rayNaif = new Ray(Player.transform.position, Player.transform.forward * 1);

        if (Physics.Raycast(rayNaif, out hitObj))
        {

            return hitObj;
        }
        else
        {
            Debug.Log("atatta");
            return hitObj;
        }
    }

    public int BulletDamege(int playerHp, int bulletDamege)
    {

        return playerHp -= bulletDamege;

    }

}
