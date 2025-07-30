using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private Joystick _shootJoystick;
    [SerializeField] private GameObject _gunFlash;
    [SerializeField] private Transform _barrel;
    [SerializeField] private GameObject _bulletPfb;
    private List<GameObject> bullets = new List<GameObject>();
    private int i;
    private float speedGun = 0.3f;
    private bool canAttack;
    void Start()
    {
        i = 0;
        speedGun = 0.2f;
        canAttack = true;
    }

    void Update()
    {
        if (_shootJoystick.Direction.magnitude > 0.1f)
        {
            Shoot();
        }    
    }


    private void Shoot()
    {
        if(!canAttack)
        {
            return;
        }
        StartCoroutine(ShowGunFlash());
        GameObject bulletx = Instantiate(_bulletPfb);
        bullets.Add(bulletx);
        bulletx.GetComponent<BulletMovement>().SetPos(_barrel);
        bulletx.GetComponent<BulletMovement>().SetDicrection(_shootJoystick.Direction);
        bulletx.SetActive(true);
        Debug.Log("Shoot");
        StartCoroutine(CountTime());
    }    

    private IEnumerator ShowGunFlash()
    {
        _gunFlash.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        _gunFlash.SetActive(false);
    }
    private IEnumerator CountTime()
    {
        canAttack = false;
        yield return new WaitForSeconds(speedGun);
        canAttack = true;
    }
}
