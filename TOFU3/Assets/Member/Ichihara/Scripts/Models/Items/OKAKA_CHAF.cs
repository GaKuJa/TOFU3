using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OKAKA_CHAF : BaseItemStatus
{
    //Playerオブジェクト
    public GameObject Player;
    //Playerのメッシュを取得
    private MeshRenderer _tofuMesh;

    //透明度
    [SerializeField, Range(0.0f, 1.0f)]
    private float _changeAlpha = default;

    private void ItemEffect()
    {
        do
        {
            _elapsedTime += Time.deltaTime;

            if (_elapsedTime >= _effectTime) { _endFlag = true; }

            _tofuMesh.material.color = new Color(0.0f, 0.0f, 0.0f, _changeAlpha);

        } while (_endFlag == false);

        EndItemEffect();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player = other.gameObject;
            AssignPlayerComponent(Player);
            ItemEffect();
        }

    }

    //接触したオブジェクトの情報を渡す
    private void AssignPlayerComponent(GameObject obj)
    {
        _tofuMesh = obj.GetComponent<MeshRenderer>();
    }
}
