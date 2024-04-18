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
        private BulletView BulletView;
        private BulletScriptableObject bulletScriptableObject;
        private List<PooledBullet> pooledBullets = new List<PooledBullet>();

        public BulletPool(BulletView bulletView, BulletScriptableObject bulletScriptableObject)
        {
            this.BulletView = bulletView;
            this.bulletScriptableObject = bulletScriptableObject;
        }
        public class PooledBullet
        {
            public BulletController Bullet;
            public bool isUsed;
        }
    }
}

