using System;
using System.Collections.Generic;

namespace CosmicCuration.Utilities
{
    public class GenericObjectPool<T> where T : class
    {
        private List<PooledItem<T>> pooledItems = new List<PooledItem<T>>();
        protected T GetItem()
        {
            if(pooledItems.Count > 0)
            {
                PooledItem<T> pooledItem = pooledItems.Find(item => !item.isUsed);
                if(pooledItem != null)
                {
                    pooledItem.isUsed = true;
                    return pooledItem.Item;
                }     
            }
            return createNewPooledItem();
        }

        private T createNewPooledItem()
        {
            PooledItem<T> newItem = new PooledItem<T>();
            newItem.Item = createItem();
            newItem.isUsed = true;

            pooledItems.Add(newItem);

            return newItem.Item;
        }

        protected virtual T createItem()
        {
            throw new NotImplementedException("Child class haven't implemented createItem() method");
            // Need to override this method in child class
        }

        public void ReturnItem(T itemToReturn)
        {
            PooledItem<T> pooledItem = pooledItems.Find(i => i.Item.Equals(itemToReturn));
            if(pooledItem != null)
            {
                pooledItem.isUsed = false;
            }
        }

        public class PooledItem<T>
        {
            public T Item;
            public bool isUsed;
        }
    }
}


