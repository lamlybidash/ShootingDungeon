using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : MonoBehaviour
{
    private List<T> pool = new List<T>();
    private T prefab;
    private Transform parent;
    public ObjectPool(T prefab, int initialSize, Transform parent = null)
    {
        this.prefab = prefab;
        this.parent = parent;
        for (int i = 0; i < initialSize; i++)
        {
            T obj = GameObject.Instantiate(prefab, parent);
            obj.gameObject.SetActive(false);
            pool.Add(obj);
        }
    }

    public T Get()
    {
        foreach (var item in pool)
            if (!item.gameObject.activeInHierarchy)
                return item;

        T newObj = GameObject.Instantiate(prefab, parent);
        newObj.gameObject.SetActive(false);
        pool.Add(newObj);
        return newObj;
    }
    public void ReturnToPool(T obj)
    {
        obj.gameObject.SetActive(false);
    }
}