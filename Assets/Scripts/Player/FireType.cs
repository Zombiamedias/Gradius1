using UnityEngine;

public abstract class FireType
{
    protected ProjectilePool projectilePool;
    protected Transform firePoint;

    public FireType(ProjectilePool projectilePool, Transform firePoint)
    {
        this.projectilePool = projectilePool;
        this.firePoint = firePoint;
    }
    public abstract void Fire();
}
public class SingleShot : FireType
{
    private int projectileIndex; // projectile index

    public SingleShot(ProjectilePool projectilePool, Transform firePoint, int projectileIndex) : base(projectilePool, firePoint)
    {
        this.projectileIndex = projectileIndex; // set index
    }

    public override void Fire()
    {
        GameObject projectile = projectilePool.GetProjectile(projectileIndex); // get projectile from pool
        if (projectile != null)
        {
            projectile.transform.position = firePoint.position; // Set projectile position
            projectile.SetActive(true); // Projectile activate
        }
    }
}

public class DoubleShot : FireType
{
    private int projectileIndex; // projectile index

    public DoubleShot(ProjectilePool projectilePool, Transform firePoint, int projectileIndex) : base(projectilePool, firePoint)
    {
        this.projectileIndex = projectileIndex; // Projectile index
    }

    public override void Fire()
    {
        for (int i = -1; i <= 1; i += 2) // shoot in 2 positions of fire point center 
        {
            GameObject projectile = projectilePool.GetProjectile(projectileIndex);
            if (projectile != null)
            {
                projectile.transform.position = firePoint.position + new Vector3(0, i * 0.5f, 0);
                projectile.SetActive(true);
            }
        }
    }
}

public class TripleShot : FireType
{
    private int projectileIndex; // projectile index

    public TripleShot(ProjectilePool projectilePool, Transform firePoint, int projectileIndex) : base(projectilePool, firePoint)
    {
        this.projectileIndex = projectileIndex; // Set index
    }

    public override void Fire()
    {
        for (int i = -1; i <= 1; i++) // shoot 3 projectiles in a row from center point of center
        {
            GameObject projectile = projectilePool.GetProjectile(projectileIndex);
            if (projectile != null)
            {
                projectile.transform.position = firePoint.position + new Vector3(0, i * 0.5f, 0);
                projectile.SetActive(true);
            }
        }
    }
}

