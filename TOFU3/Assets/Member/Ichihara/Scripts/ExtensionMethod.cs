using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtensionMethod : MonoBehaviour
{

}
static class OriginalMethod
{
    /// <summary>
    /// �I�u�W�F�N�g���A�N�e�B�u����false���A��A�N�e�B�u����true��Ԃ����\�b�h
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static bool OpposeActive(this GameObject obj)
    {
        bool investigateObject = false;

        if (obj.activeSelf == true)
        {
            investigateObject = false;
        }
        else if (obj.activeSelf == false)
        {
            investigateObject = true;
        }

        return investigateObject;

    }

    public static int CountGameObjectActive(this List<GameObject> array)
    {
        int countTrue = 0;

        foreach(GameObject obj in array)
        {
            if(obj.activeSelf == true)
            {
                countTrue++;
            }
        }

        return countTrue;
    }
}

