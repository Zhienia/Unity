using System.Collections.Generic;
using UnityEngine;

public class PoolObjects<T> where T : MonoBehaviour
{
    public T prefabBomb { get; }
    public bool autoExpand { get; set; }
    public Transform container { get; }
    private List<T> pool;

    public PoolObjects(T prefab, int count)
    {
        this.prefabBomb = prefab;
        this.container = null;

        this.CreatePool(count);
    }

    public PoolObjects(T prefab, int count, Transform container)
    {
        this.prefabBomb = prefab;
        this.container = container;

        this.CreatePool(count);
    }

    private void CreatePool(int count)
    {
        this.pool = new List<T>();

        for(int i = 0; i < count; i++)
        {
            this.CreateObject();
        }
    }

    private T CreateObject(bool isActiveByDefault = false)
    {
        T createObject = Object.Instantiate(this.prefabBomb, this.container);
        createObject.gameObject.SetActive(isActiveByDefault);
        this.pool.Add(createObject);
        return createObject;
    }

    public bool HasFreeElement(out T element)
    {
        foreach(T mono in pool)
        {
            if (!mono.gameObject.activeInHierarchy)
            {
                element = mono;
                mono.gameObject.SetActive(true);
                return true;
            }
        }

        element = null;
        return false;
    }

    public T GetFreeElement()
    {
        if (this.HasFreeElement(out T element))
            return element;

        if (this.autoExpand)
            return this.CreateObject(true);

        throw new System.Exception($"There is no elements in pool of type{typeof(T)}");
    }
}
