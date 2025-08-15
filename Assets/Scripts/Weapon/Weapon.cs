using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Weapon : MonoBehaviour
{
    [SerializeField] public WeaponData data;
    protected string nameW;
    protected float damage;
    protected float reloadTime;  // Thời gian nạp một băng đạn
    protected float timePerShot; // Thời gian giữa 2 lần bắn (2 viên đạn liên tiếp)
    protected float speedBullet; // Tốc độ đạn bay
    protected float rangeBullet; // Tầm bay của đạn
    protected int magazineCapacity; // Sức chứa của 1 băng đạn -> Nạp đạn sẽ mất tất cả đạn còn dư trong băng cũ
    protected GameObject bulletPfb;
    protected GameObject listBulletParent; //GameObject chứa object đạn
    protected bool canAttack;
    protected bool isReloading;
    protected List<GameObject> bullets;
    protected GameObject gunFlash;
    protected Transform barrel;
    protected int currentBullet;    // Số lượng đạn hiện tại của băng đạn
    protected int currentMagazine;  // Số lượng băng đạn khởi đầu của súng
    protected Sprite iconGun;
    public event Action<float> eReload;
    public event Action<float, int, int> eShoot;

    private void Start()
    {
        InitData();
    }
    public void InitData()
    {
        nameW = data.nameW;
        damage = data.damage;
        reloadTime = data.reloadTime;
        speedBullet = data.speedBullet;
        rangeBullet = data.rangeBullet;
        bulletPfb = data.bulletPfb;
        currentMagazine = data.magazines;
        magazineCapacity = data.magazineCapacity;
        currentBullet = magazineCapacity;
        timePerShot = data.timePerShot;
        iconGun = data.iconGun;
        canAttack = true;
        isReloading = false;
        bullets = new List<GameObject>();
        gunFlash = transform.Find("GunFlash").gameObject;
        barrel = transform.Find("Barrel");
        listBulletParent = GameObject.FindWithTag("Bullets");

    }

    public virtual void Shoot(Vector2 dic)
    {
        
    }

    protected void InvokeEReload(float time)
    {
        eReload?.Invoke(time);
    }
    protected void InvokeEShoot(float time, int current, int total)
    {
        eShoot?.Invoke(time, current, total);
    }
    public int GetMagazineCapacity()
    {
        return magazineCapacity;
    }

    public string GetNameGun()
    {
        return nameW;
    }    

    public Sprite GetIconGun() 
    {
        return iconGun; 
    }
}
