using UnityEngine;

public class BulletLinearShooter : MonoBehaviour
{
    private string ElectronPrefabPath = "Prefab/ElectronBullet";
    private string ProtonPrefabPath = "Prefab/ProtonBullet";
    private string NeutralPrefabPath = "Prefab/NeutralBullet";

    public enum BulletType
    {
        Proton,
        Electon,
        Neutral
    }

    [Range(0f, float.MaxValue)] 
    public float ShootInterval;

    [Range(0f, float.MaxValue)]
    public float Speed;

	[Range(0f, float.MaxValue)]
	public float LifeTime;

    public BulletType Bullet;

    public EaseType EaseType;

    public Vector2 ShootDirection;

	void Start () 
    {
        InvokeRepeating("Shoot", ShootInterval, ShootInterval);
	}
	
    private void Shoot()
    {
		if(enabled)
		{
        GameObject bullet ;
        if (Bullet == BulletType.Electon)
        {
            bullet = Instantiate(Resources.Load(ElectronPrefabPath), transform.position, Quaternion.identity) as GameObject;
        }
        else if (Bullet == BulletType.Proton)
        {
            bullet = Instantiate(Resources.Load(ProtonPrefabPath), transform.position, Quaternion.identity) as GameObject;
        }
        else
        {
            bullet = Instantiate(Resources.Load(NeutralPrefabPath), transform.position, Quaternion.identity) as GameObject;
        }
        bullet.MoveTo(transform.position + new Vector3(ShootDirection.x, ShootDirection.y, 0) * 2000f, 2000f / Speed, 0f, EaseType);
		Destroy(bullet, LifeTime);
		}
    }
}
