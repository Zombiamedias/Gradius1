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
    private int projectileIndex; // Índice del proyectil

    public SingleShot(ProjectilePool projectilePool, Transform firePoint, int projectileIndex) : base(projectilePool, firePoint)
    {
        this.projectileIndex = projectileIndex; // Asigna el índice
    }

    public override void Fire()
    {
        GameObject projectile = projectilePool.GetProjectile(projectileIndex); // Obtén el proyectil de la pool
        if (projectile != null)
        {
            projectile.transform.position = firePoint.position; // Establece la posición del proyectil
            projectile.SetActive(true); // Activa el proyectil
        }
    }
}

public class DoubleShot : FireType
{
    private int projectileIndex; // Índice del proyectil

    public DoubleShot(ProjectilePool projectilePool, Transform firePoint, int projectileIndex) : base(projectilePool, firePoint)
    {
        this.projectileIndex = projectileIndex; // Asigna el índice
    }

    public override void Fire()
    {
        for (int i = -1; i <= 1; i += 2) // Dispara dos proyectiles, uno arriba y uno abajo
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
    private int projectileIndex; // Índice del proyectil

    public TripleShot(ProjectilePool projectilePool, Transform firePoint, int projectileIndex) : base(projectilePool, firePoint)
    {
        this.projectileIndex = projectileIndex; // Asigna el índice
    }

    public override void Fire()
    {
        for (int i = -1; i <= 1; i++) // Dispara tres proyectiles, uno en el medio y uno arriba y abajo
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

