using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    private float _speed;
    private Vector2 _dic = new Vector2(0, 0);
    public float angleOffset = 0f;
    private float _maxDistance = 0f;
    private float _tempDistance = 0f;
    void Update()
    {
        if(_tempDistance <= _maxDistance)
        {
            transform.position += new Vector3(_dic.x * _speed * Time.deltaTime, _dic.y * _speed * Time.deltaTime, 0);
            _tempDistance += _speed * Time.deltaTime;
        }   
        else
        {
            _tempDistance = 0;
            gameObject.SetActive(false);
        }
    }

    public void SetDicrection(Vector2 dic)
    {
        _tempDistance = 0;
        _dic = dic.normalized;
        //Random độ giật -> + thêm góc nhỏ
        float angle = Mathf.Atan2(_dic.y, _dic.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle + angleOffset);
    }

    public void SetPos(Transform pos)
    {
        transform.position = pos.position;
    }
    public void SetRange(float range)
    {
        _maxDistance = range;
    }
    public void SetSpeed(float speed)
    {
        _speed = speed;
    }

}