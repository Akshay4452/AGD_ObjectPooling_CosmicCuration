using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.Bullets
{
    // 1. Create class of pooled bullet
    // 2. Create this pool via PlayerService
    // 3. Create constructor

    public class BulletPool
    {
        private BulletView bulletView;
        private BulletScriptableObject bulletScriptableObject;
        private List<PooledBullet> pooledBullets = new List<PooledBullet>();

        public BulletPool(BulletView bulletView, BulletScriptableObject bulletScriptableObject)
        {
            this.bulletView = bulletView;
            this.bulletScriptableObject = bulletScriptableObject;
        }

        public BulletController GetBullet()
        {
            if(pooledBullets.Count == 0)
            {
                BulletController bulletController = createNewPooledBullet();
                return bulletController;
            }
            else
            {
                PooledBullet pooledBullet = pooledBullets.Find(item => !item.isUsed);
                if(pooledBullet != null)
                {
                    pooledBullet.isUsed = true;
                    return pooledBullet.BulletController;
                }
                else
                {
                    return createNewPooledBullet(); // Add new Bullet to the pool when all the bullets in pool are being used
                }
            }
        }

        private BulletController createNewPooledBullet()
        {
            PooledBullet pooledBullet = new PooledBullet();
            pooledBullet.BulletController = new BulletController(bulletView, bulletScriptableObject);
            pooledBullet.isUsed = true;
            pooledBullets.Add(pooledBullet); // Add newly created bullet into Bullet Pool
            return pooledBullet.BulletController;
        }

        public void ReuseBullet(BulletController bulletController)
        {
            PooledBullet pooledBullet = pooledBullets.Find(item => item.BulletController == bulletController);
            if (pooledBullet != null)
                pooledBullet.isUsed = false;
            else
                Debug.LogError("Pooled Bullet not found");
        }

        public int GetPoolSize() { return pooledBullets.Count; } // Need to delete later

        
        public class PooledBullet
        {
            public BulletController BulletController;
            public bool isUsed;
        }
    }
}

