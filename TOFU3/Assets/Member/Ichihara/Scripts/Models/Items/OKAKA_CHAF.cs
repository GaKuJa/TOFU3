using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OKAKA_CHAF : BaseItemStatus
{
    //Player�I�u�W�F�N�g
    public GameObject Player;
    //Player�̃��b�V�����擾
    private MeshRenderer _tofuMesh;

    //�����x
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

    //�ڐG�����I�u�W�F�N�g�̏���n��
    private void AssignPlayerComponent(GameObject obj)
    {
        _tofuMesh = obj.GetComponent<MeshRenderer>();
    }
}
