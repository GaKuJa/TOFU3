using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    // Item tag
    private string YubaTag = "Yuba";
    private string StimTag = "Stim";
    private string OkakaTag = "Okaka";
    private string YuzuTag = "Yuzu";
    private string AgeTofuTag = "AgeTofu";
    private string MomijiTag = "Momiji";
    private string OkuraTag = "Okura";

    // 各アイテムの取得状況
    [System.NonSerialized] public bool YubaShield = false;
    [System.NonSerialized] public bool DashiStim = false;
    [System.NonSerialized] public bool OkakaChaf = false;
    [System.NonSerialized] public bool YuzuRadar = false;
    [System.NonSerialized] public bool AgeTofu = false;
    [System.NonSerialized] public bool MomijiRed = false;
    [System.NonSerialized] public bool OkuraTorimoti = false;

    // 判定
    private void OnTriggerEnter(Collider other)
    {
        //YUBA-SHIELD
        if (other.gameObject.tag == YubaTag)
        {
            other.gameObject.SetActive(false);
            YubaShield = true;
        }

        //DASHI-STIM
        else if (other.gameObject.tag == StimTag)
        {
            other.gameObject.SetActive(false);
            DashiStim = true;
        }

         //OKAKA-CHAF
        else if (other.gameObject.tag == OkakaTag)
        {
            other.gameObject.SetActive(false);
            OkakaChaf = true;
        }

        //YUZU-RADAR
        else if (other.gameObject.tag == YuzuTag)
        {
            other.gameObject.SetActive(false);
            YuzuRadar = true;
        }

        //AGE-TOFUMODE
        else if (other.gameObject.tag == AgeTofuTag)
        {
            other.gameObject.SetActive(false);
            AgeTofu = true;
        }

        //MOMIJI-RED
        else if (other.gameObject.tag == MomijiTag)
        {
            other.gameObject.SetActive(false);
            MomijiRed = true;
        }

        //OKURA-TORIMOCHI
        else if (other.gameObject.tag == OkuraTag)
        {
            other.gameObject.SetActive(false);
            OkuraTorimoti = true;
        }
    }
}
