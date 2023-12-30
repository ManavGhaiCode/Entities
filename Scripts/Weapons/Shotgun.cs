using UnityEngine;

public class Shotgun : Weapon {
    public Transform[] FirePoints;

    public override void Shoot() {
        int[] UsedIndexs = new int[5];

        for (int i = 0; i < 5; i++) {
            int FireIndex = Random.Range(0, FirePoints.Length);

            for (int j = 0; j < UsedIndexs.Length; j++) {
                while (UsedIndexs[j] == FireIndex) {
                    FireIndex = Random.Range(0, FirePoints.Length);
                }
            }

            GameObject bullet = Instantiate(BulletPrefab, FirePoints[FireIndex].position, FirePoints[FireIndex].rotation);
            Bullet bulletScript = bullet.GetComponent<Bullet>();
            bulletScript.Damage = bulletDamage;
            bulletScript.lifespan = bulletLifespan;

            bullet.GetComponent<Rigidbody2D>().AddForce(FirePoints[FireIndex].up * bulletSpeed, ForceMode2D.Impulse);
            UsedIndexs[i] = FireIndex;
        }
    }
}