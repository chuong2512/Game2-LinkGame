using PathologicalGames;

namespace ChuongCustom
{
    using UnityEngine;

    public class PoolConstant
    {
        //--------------------POOL NAME--------------------
        public static readonly string PoolEnemy = "Enemy";
        public static readonly string PoolParticle = "Particle";
        public static readonly string PoolItem = "Item";

        public static readonly string PoolBullet = "Bullet";

        //------------------ITEM---------------------------------

        //---------------------PARTICLE---------------------------------


        //---------------------ENEMY---------------------------------
        //---------------------BULLET---------------------------------
    }

    public static class PoolContainer
    {
        public static Transform SpawnEnemy(Transform prefab, Vector3 pos, Quaternion rot, Transform parent = null)
        {
            return PoolManager.Pools[PoolConstant.PoolEnemy].Spawn(prefab, pos, rot, parent);
        }

        public static Transform SpawnEnemy(string name, Vector3 pos, Quaternion rot, Transform parent = null)
        {
            return PoolManager.Pools[PoolConstant.PoolEnemy].Spawn(name, pos, rot, parent);
        }

        public static Transform SpawnEnemy(Transform prefab, Transform parent = null)
        {
            return PoolManager.Pools[PoolConstant.PoolEnemy].Spawn(prefab, parent);
        }

        public static Transform SpawnEnemy(string name, Transform parent = null)
        {
            return PoolManager.Pools[PoolConstant.PoolEnemy].Spawn(name, parent);
        }

        public static Transform SpawnFX(Transform prefab, Vector3 pos, Quaternion rot, Transform parent = null)
        {
            return PoolManager.Pools[PoolConstant.PoolParticle].Spawn(prefab, pos, rot, parent);
        }

        public static Transform SpawnFX(GameObject prefab, Vector3 pos, Quaternion rot, Transform parent = null)
        {
            return SpawnFX(prefab.gameObject, pos, rot, parent);
        }

        public static Transform SpawnFX(string name, Vector3 pos, Quaternion rot, Transform parent = null)
        {
            return PoolManager.Pools[PoolConstant.PoolParticle].Spawn(name, pos, rot, parent);
        }

        public static Transform SpawnFX(Transform prefab, Transform parent = null)
        {
            return PoolManager.Pools[PoolConstant.PoolParticle].Spawn(prefab, parent);
        }

        public static Transform SpawnFX(string name, Transform parent = null)
        {
            return PoolManager.Pools[PoolConstant.PoolParticle].Spawn(name, parent);
        }

        public static Transform SpawnItem(Transform prefab, Vector3 pos, Quaternion rot, Transform parent = null)
        {
            return PoolManager.Pools[PoolConstant.PoolItem].Spawn(prefab, pos, rot, parent);
        }

        public static Transform SpawnItem(GameObject prefab, Vector3 pos, Quaternion rot, Transform parent = null)
        {
            return SpawnItem(prefab.transform, pos, rot, parent);
        }

        public static Transform SpawnItem(string name, Vector3 pos, Quaternion rot, Transform parent = null)
        {
            return PoolManager.Pools[PoolConstant.PoolItem].Spawn(name, pos, rot, parent);
        }

        public static Transform SpawnItem(Transform prefab, Transform parent = null)
        {
            return PoolManager.Pools[PoolConstant.PoolItem].Spawn(prefab, parent);
        }

        public static Transform SpawnItem(string name, Transform parent = null)
        {
            return PoolManager.Pools[PoolConstant.PoolItem].Spawn(name, parent);
        }

        public static void DeSpawnEnemy(GameObject trans)
        {
            DeSpawnEnemy(trans.transform);
        }

        public static void DeSpawnItem(GameObject trans)
        {
            DeSpawnItem(trans.transform);
        }

        public static void DeSpawnItem(Transform trans)
        {
            PoolManager.Pools[PoolConstant.PoolItem].Despawn(trans.transform);
        }

        public static void DeSpawnEnemy(Transform trans)
        {
            PoolManager.Pools[PoolConstant.PoolEnemy].Despawn(trans);
        }

        public static void DeSpawnFX(GameObject trans)
        {
            DeSpawnFX(trans.transform);
        }

        public static void DeSpawnFX(Transform trans)
        {
            PoolManager.Pools[PoolConstant.PoolParticle].Despawn(trans);
        }

        /*public static UbhBullet SpawnBullet(GameObject prefab, Vector3 position)
        {
            UbhBullet bullet = null;
            Transform bulletInstance =
                PoolManager.Pools[PoolConstant.PoolBullet].Spawn(prefab, position, Quaternion.identity);

            if (bulletInstance != null)
            {
                bullet = bulletInstance.GetComponent<UbhBullet>();
                bullet.SetActive(true);
                UbhBulletManager.instance.AddBullet(bullet);
            }

            return bullet;
        }*/


        /*public static void DeSpawnBullet(Transform trans)
        {
            DeSpawnBullet(trans.gameObject);
        }*/


        /*public static void DeSpawnBullet(GameObject trans)
        {
            UbhBullet bullet = trans.GetComponent<UbhBullet>();
            if (bullet != null)
            {
                bullet.OnFinishedShot();
                UbhBulletManager.instance.RemoveBullet(bullet, false);
                bullet.SetActive(false);
            }

            PoolManager.Pools[PoolConstant.PoolBullet].Despawn(trans.transform);
        }*/
    }
}