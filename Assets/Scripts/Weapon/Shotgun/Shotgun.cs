using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    private List<GameObject> _bulletShotGun;
    private int _maxBulletPerShot = 5;  // Số tia đạn trong 1 lần bắn
    private int _maxShot; // Số phát bắn liên tục trong 1 lần nạp đạn
    private int _countShot; //đếm xem bắn được bao nhiêu phát liên tục
    public override void Shoot(Vector2 dic)
    {
        base.Shoot(dic);
        if (!canAttack)
        {
            return;
        }
        Debug.Log("Shoot");

        //Show gun flash
        StartCoroutine(ShowGunFlash());
        int i;
        for (i = 0; i < _maxBulletPerShot; i++)
        {
            GameObject bulletx;
            bulletx = null;
            bulletx = FindBullet();
            if (bulletx == null)
            {
                bulletx = Instantiate(bulletPfb);
                Debug.Log("add bullet");
                bullets.Add(bulletx);
                bulletx.transform.SetParent(listBulletParent.transform, false);
                bulletx.GetComponent<BulletMovement>().SetPos(barrel);
                bulletx.GetComponent<BulletMovement>().SetSpeed(speedBullet);
                bulletx.GetComponent<BulletMovement>().SetDicrection(dic);
                bulletx.GetComponent<BulletMovement>().SetRange(rangeBullet);
                bulletx.SetActive(true);
            }
        }

        //Reload bullet
        StartCoroutine(CountTime());
    }
    private IEnumerator ShowGunFlash()
    {
        gunFlash.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        gunFlash.SetActive(false);
    }
    private IEnumerator CountTime()
    {
        canAttack = false;
        yield return new WaitForSeconds(reloadTime);
        canAttack = true;
    }

    //pooling
    private GameObject FindBullet()
    {
        foreach (var bullet in bullets)
        {
            if (!bullet.activeInHierarchy)
            {
                return bullet;
            }
        }
        return null;
    }
}
