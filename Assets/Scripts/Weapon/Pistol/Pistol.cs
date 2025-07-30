using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    public override void Shoot(Vector2 dic)
    {
        base.Shoot(dic);
        if (!canAttack)
        {
            return;
        }
        Debug.Log("Shoot");
        if(currentBullet == 0)
        {
            currentBullet = magazineCapacity;
            //TODO
        }    
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
        bulletx.GetComponent<BulletMovement>().SetPos(barrel);
        bulletx.GetComponent<BulletMovement>().SetSpeed(speedBullet);
        bulletx.GetComponent<BulletMovement>().SetDicrection(dic);
        bulletx.GetComponent<BulletMovement>().SetRange(rangeBullet);
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
