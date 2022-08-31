using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OKAKA_CHAF : BaseItemStatus
{
    //Playerオブジェクト
    [SerializeField]
    private GameObject _tofu = null;

    private MeshRenderer _tofuMesh = null;

    //透明度
    [SerializeField, Range(0.0f, 1.0f)]
    private float _alpha = default;

    // Start is called before the first frame update
    void Start()
    {
        _tofuMesh = _tofu.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        EndItemEffect();

        _elapsedTime += Time.deltaTime;        
        if(_elapsedTime >= _effectTime)
        {
            _endFlag = true;
        }

        _tofuMesh.material.color = new Color(0.0f, 0.0f, 0.0f, _alpha);

    }

    private void OnTriggerEnter(Collider other)
    {
        _tofu = other.gameObject;
    }
}
