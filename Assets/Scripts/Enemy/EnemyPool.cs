using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.Enemy
{ 
    public class EnemyPool
    {
        private EnemyView enemyView;
        private EnemyScriptableObject enemyScriptableObject;
        private List<PooledEnemy> pooledEnemies = new List<PooledEnemy>();

        public EnemyPool(EnemyView enemyView, EnemyScriptableObject enemyScriptableObject)
        {
            this.enemyView = enemyView;
            this.enemyScriptableObject = enemyScriptableObject;
        }

        public EnemyController GetEnemy()
        {
            if(pooledEnemies.Count == 0)
            {
                EnemyController enemyController = createNewPooledEnemy();
                return enemyController;
            } 
            else
            {
                PooledEnemy enemyUnusedInPool = pooledEnemies.Find(enemy => !enemy.isUsed);
                if (enemyUnusedInPool != null)
                {
                    enemyUnusedInPool.isUsed = true;
                    return enemyUnusedInPool.EnemyController;
                }
                else
                {
                    return createNewPooledEnemy(); // Create new enemy in pool when all the existing enemies in pool are being used
                }
            }
        }

        public void ReturnEnemyToPool(EnemyController enemyToReturn)
        {
            PooledEnemy pooledEnemy = pooledEnemies.Find(item => item.EnemyController.Equals(enemyToReturn));
            if (pooledEnemy != null)
                pooledEnemy.isUsed = false;
            else
                Debug.LogError("Enemy cannot be pooled from Enemy Pool");
        }

        private EnemyController createNewPooledEnemy()
        {
            PooledEnemy pooledEnemy = new PooledEnemy();
            pooledEnemy.EnemyController = new EnemyController(enemyView, enemyScriptableObject.enemyData);
            pooledEnemy.isUsed = true;

            // Add the pooled enemy into the Enemy Pool
            pooledEnemies.Add(pooledEnemy);

            return pooledEnemy.EnemyController;
        }
        public class PooledEnemy
        {
            public EnemyController EnemyController;
            public bool isUsed;
        }
    }
}

