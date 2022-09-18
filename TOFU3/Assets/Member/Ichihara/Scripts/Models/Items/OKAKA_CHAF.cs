using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OKAKA_CHAF : BaseItemStatus
{
    //Player�I�u�W�F�N�g
    private GameObject _player = null;
    private ItemPickUp _pickUp = null;
    //Player�̃��b�V�����擾
    private MeshRenderer _tofuMesh = null;

    //�����x
    [SerializeField, Range(0.0f, 1.0f)]
    private float _changeAlpha = default;

    private void Update()
    {
        if (_elapsedTime > _effectTime || _pickUp.OkakaChaf == false) { return; }
        _elapsedTime += Time.deltaTime;

        ItemEffect();

        if (_elapsedTime >= _effectTime)
        {
            _endFlag = true;
            _pickUp.OkakaChaf = false;
        }
        EndItemEffect();
    }

    private void ItemEffect()
    {
        _tofuMesh.material.color = new Color(0.0f, 0.0f, 0.0f, _changeAlpha);
        Debug.Log(_tofuMesh.material.color);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.InitializeElapsedTime();
            _player = other.gameObject;
            _pickUp = _player.GetComponentInParent<ItemPickUp>();
            AssignPlayerComponent(_player);
        }
    }

    /// <summary>
    /// �ڐG�����I�u�W�F�N�g�̏���n��
    /// </summary>
    /// <param name="obj"></param>
    private void AssignPlayerComponent(GameObject obj)
    {
        _tofuMesh = obj.GetComponentInParent<MeshRenderer>();
    }
}
