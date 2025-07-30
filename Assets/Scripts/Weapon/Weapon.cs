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
    protected List<GameObject> bullets;
    protected GameObject gunFlash;
    protected Transform barrel;
    protected int currentBullet;
    protected int currentMagazine;

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
        canAttack = true;
        bullets = new List<GameObject>();
        currentBullet = magazineCapacity;
        gunFlash = transform.Find("GunFlash").gameObject;
        barrel = transform.Find("Barrel");
        listBulletParent = GameObject.FindWithTag("Bullets");
    }

    public virtual void Shoot(Vector2 dic)
    {
        
    }
    
}
