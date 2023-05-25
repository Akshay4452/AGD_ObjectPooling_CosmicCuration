using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is a Generic Object Pool Class with basic functionality, which can be inherited to implement object pools for any type of objects.
/// </summary>
/// <typeparam object Type to be pooled = "T"></typeparam>
public class GenericObjectPool<T> where T : class
{
    public List<PooledItem<T>> pooledItems = new List<PooledItem<T>>();

    public virtual T GetItem<IT>() where IT : T
    {
        if (pooledItems.Count > 0)
        {
            PooledItem<T> item = pooledItems.Find(item => !item.isUsed && item.Item is IT);
            if (item != null)
            {
                item.isUsed = true;
                return item.Item;
            }
        }
        return CreateNewPooledItem<IT>();
    }

    private T CreateNewPooledItem<IT>() where IT : T
    {
        PooledItem<T> newItem = new PooledItem<T>();
        newItem.Item = CreateItem<IT>();
        newItem.isUsed = true;
        pooledItems.Add(newItem);
        return newItem.Item;
    }

    protected virtual T CreateItem<IT>() where IT : T
    {
        throw new NotImplementedException("CreateItem() method not implemented in derived class");
    }

    public virtual void ReturnItem(T item)
    {
        PooledItem<T> pooledItem = pooledItems.Find(i => i.Item.Equals(item));
        pooledItem.isUsed = false;
    }

    public class PooledItem<T>
    {
        public T Item;
        public bool isUsed;
    }
}