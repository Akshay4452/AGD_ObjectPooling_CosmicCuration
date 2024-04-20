using CosmicCuration.Utilities;
using System.Collections.Generic;

namespace CosmicCuration.Bullets
{
    public class BulletPool : GenericObjectPool<BulletController>
    {
        private BulletView bulletPrefab;
        private BulletScriptableObject bulletSO;
        private List<PooledBullet<BulletController>> pooledBullets = new List<PooledBullet<BulletController>>();

        public BulletPool(BulletView bulletPrefab, BulletScriptableObject bulletSO)
        {
            this.bulletPrefab = bulletPrefab;
            this.bulletSO = bulletSO;
        }

        public BulletController GetBullet()
        {
            return base.GetItem();
        }

        protected override BulletController createItem() => new BulletController(bulletPrefab, bulletSO);

        public void ReturnBullet(BulletController bullet)
        {
            base.ReturnItem(bullet);
        }

        public class PooledBullet<BulletController>
        {
            public BulletController Bullet;
            public bool isUsed;
        }
    }
}