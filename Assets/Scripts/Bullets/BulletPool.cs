using CosmicCuration.Utilities;
using System.Collections.Generic;

namespace CosmicCuration.Bullets
{
    public class BulletPool : GenericObjectPool<BulletController>
    {
        private BulletView bulletPrefab;
        private BulletScriptableObject bulletSO;

        public BulletPool(BulletView bulletPrefab, BulletScriptableObject bulletSO)
        {
            this.bulletPrefab = bulletPrefab;
            this.bulletSO = bulletSO;
        }

        public BulletController GetBullet() { return GetItem(); }

        protected override BulletController createItem() => new BulletController(bulletPrefab, bulletSO);

        public void ReturnBullet(BulletController bulletToReturn) { ReturnItem(bulletToReturn); }
    }
}