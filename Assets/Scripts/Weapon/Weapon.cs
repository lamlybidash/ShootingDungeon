using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public abstract class Weapon : MonoBehaviour, IItem, IPickupable
{
    public string Name { get; private set; }
    public Sprite Icon { get; private set; }
    public TypeIItem TypeItem { get; private set; }
    [SerializeField] public WeaponData data;
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
    protected string _attackACName;
    protected string _reloadACName;
    public event Action<float> eReload;
    public event Action<float, int, int> eShoot;

    public WeaponController wc;

    private void Awake()
    {
        InitData();

    }
    private void Start()
    {
    }
    public void InitData()
    {
        Name = data.nameW;
        Icon = data.iconGun;
        TypeItem = TypeIItem.Weapon;

        damage = data.damage;
        reloadTime = data.reloadTime;
        speedBullet = data.speedBullet;
        rangeBullet = data.rangeBullet;
        bulletPfb = data.bulletPfb;
        currentMagazine = data.magazines;
        magazineCapacity = data.magazineCapacity;
        currentBullet = magazineCapacity;
        timePerShot = data.timePerShot;
        _attackACName = data.acName + "_attack";
        _reloadACName = data.acName +"_reload";
        canAttack = true;
        isReloading = false;
        bullets = new List<GameObject>();
        gunFlash = transform.Find("GunFlash")?.gameObject;
        barrel = transform.Find("Barrel");
        listBulletParent = GameObject.FindWithTag("Bullets");
        GetComponent<ItemDrop>().SetupItemDrop(this,this);
        wc = GameObject.FindGameObjectWithTag("WeaponController").GetComponent<WeaponController>();
        
    }

    public virtual void Shoot(Vector2 dic)
    {
        if(!canAttack)
        {
            return;
        } 
        if (!string.IsNullOrEmpty(_attackACName))
        {
            SoundManager.Instance.PlaySFX(_attackACName);
        }
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

    public void ClearAllEvent()
    {
        eReload = null;
        eShoot = null;
    } 

    public void Pickup()
    {
        Debug.Log($"Pick up {Name}");
        wc.EquipWeapon(this);
    }
}
