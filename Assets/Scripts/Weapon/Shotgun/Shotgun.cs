using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    private List<GameObject> _bulletShotGun;
    private int _maxBulletPerShot = 5;  // Số tia đạn trong 1 lần bắn
    private int _maxShot = 2; // Số phát bắn liên tục trong 1 lần nạp đạn
    private int _countShot; // đếm xem bắn được bao nhiêu phát liên tục
    private float maxE = 30f; // Góc quạt tối đa của chùm đạn
    private float epb; // Góc giữa mỗi viên đạn
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
        epb = maxE / (_maxBulletPerShot - 1);
        for (i = 0; i < _maxBulletPerShot; i++)
        {
            Vector2 dictBullet;
            dictBullet = RotateVector(dic, (maxE / 2) - i * epb);
            GameObject bulletx;
            bulletx = null;
            bulletx = FindBullet();
            Debug.Log("i = " + i);
            Debug.Log("goc = " + ((maxE / 2) - i * epb));
            if (bulletx == null)
            {
                bulletx = Instantiate(bulletPfb);
                Debug.Log("add bullet");
                bullets.Add(bulletx);
                bulletx.transform.SetParent(listBulletParent.transform, false);
            }
            bulletx.GetComponent<BulletMovement>().SetPos(barrel);
            bulletx.GetComponent<BulletMovement>().SetSpeed(speedBullet);
            bulletx.GetComponent<BulletMovement>().SetDicrection(dictBullet);
            bulletx.GetComponent<BulletMovement>().SetRange(rangeBullet);
            bulletx.SetActive(true);
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


    // Trả về vector lệch degrees độ so với vector hướng dic
    private Vector2 RotateVector(Vector2 dic, float degrees)
    {
        float radians = degrees * Mathf.Deg2Rad;
        float cos = Mathf.Cos(radians);
        float sin = Mathf.Sin(radians);
        return new Vector2(
            dic.x * cos - dic.y * sin,
            dic.x * sin + dic.y * cos
        );
    }
}
