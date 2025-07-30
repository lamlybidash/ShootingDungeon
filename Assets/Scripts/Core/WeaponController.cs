using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private Weapon _weaponCurrent;
    [SerializeField] private Joystick _shootJoystick;
    //[SerializeField] private GameObject _gunFlash;
    //[SerializeField] private Transform _barrel;
    //[SerializeField] private GameObject _bulletPfb;
    private List<GameObject> bullets = new List<GameObject>();
    private int i;
    private float _speedGun = 0.3f;
    private bool _canAttack;
    void Start()
    {
        i = 0;
        _speedGun = 0.2f;
        _canAttack = true;
    }

    void Update()
    {
        if (_shootJoystick.Direction.magnitude > 0.1f)
        {
            _weaponCurrent.Shoot(_shootJoystick.Direction);
        }
    }
    //public void Shoot()
    //{
    //    if (!_canAttack)
    //    {
    //        return;
    //    }
    //    StartCoroutine(ShowGunFlash());
    //    GameObject bulletx = Instantiate(_bulletPfb);
    //    bullets.Add(bulletx);
    //    bulletx.GetComponent<BulletMovement>().SetPos(_barrel);
    //    bulletx.GetComponent<BulletMovement>().SetDicrection(_shootJoystick.Direction);
    //    bulletx.SetActive(true);
    //    Debug.Log("Shoot");
    //    StartCoroutine(CountTime());
    //}
    //private IEnumerator ShowGunFlash()
    //{
    //    _gunFlash.SetActive(true);
    //    yield return new WaitForSeconds(0.05f);
    //    _gunFlash.SetActive(false);
    //}
    //private IEnumerator CountTime()
    //{
    //    _canAttack = false;
    //    yield return new WaitForSeconds(_speedGun);
    //    _canAttack = true;
    //}
}
