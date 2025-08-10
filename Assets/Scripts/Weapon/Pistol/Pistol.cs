using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    private BulletMovement _bulletMovementTemp;
    public override void Shoot(Vector2 dic)
    {
        base.Shoot(dic);
        if (!canAttack)
        {
            return;
        }
        if(currentBullet == 0)
        {
            if(!isReloading)
            {
                // Nạp đạn ∞
                StartCoroutine(ReloadMagazine());
            }
            return;
        }

        currentBullet--;
        Debug.Log("current bullet = " + currentBullet);
        //Show gun flash
        StartCoroutine(ShowGunFlash());
        GameObject bulletx;
        bulletx = null;
        bulletx = FindBullet();
        if (bulletx == null)
        {
            bulletx = Instantiate(bulletPfb);
            bullets.Add(bulletx);
            bulletx.transform.SetParent(listBulletParent.transform, false);
        }
        _bulletMovementTemp = bulletx.GetComponent<BulletMovement>();
        //bulletx.GetComponent<BulletMovement>().SetPos(barrel);
        //bulletx.GetComponent<BulletMovement>().SetSpeed(speedBullet);
        //bulletx.GetComponent<BulletMovement>().SetDicrection(dic);
        //bulletx.GetComponent<BulletMovement>().SetRange(rangeBullet);

        _bulletMovementTemp.SetPos(barrel);
        _bulletMovementTemp.SetSpeed(speedBullet);
        _bulletMovementTemp.SetDicrection(dic);
        _bulletMovementTemp.SetRange(rangeBullet);

        bulletx.SetActive(true);

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
        InvokeEShoot(timePerShot, currentBullet, magazineCapacity);
        yield return new WaitForSeconds(timePerShot);
        canAttack = true;
    }

    //Nạp đạn
    private IEnumerator ReloadMagazine()
    {
        Debug.Log("Nạp đạn");
        isReloading = true;
        InvokeEReload(reloadTime);
        yield return new WaitForSeconds(reloadTime);
        Debug.Log("Nạp đạn xong");
        isReloading = false;
        currentBullet = magazineCapacity;
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
