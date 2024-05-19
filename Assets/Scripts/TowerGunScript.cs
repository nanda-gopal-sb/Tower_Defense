using UnityEngine;
using UnityEngine.UI;

public class TowerGunScript : MonoBehaviour
{
    public SpriteRenderer Sprite ;
    public Sprite HomeSprite ;
    public Sprite EnemySprite;  
    private float nextFire;
    private Vector3 Direction;
    private float fireRate = 1f;
    private float Damage = 1f;
    private float TowerHealth = 6;
    public Transform HomeBase;
    RaycastHit2D collide;
    public HomeBase Home;
    public Projectile projectile;
    public Text Score; 
    public bool isChanged = false ; 
    public Vector3 GetPos()
    {
        return gameObject.transform.position;
    }
    public void SetScore()
    {
        Score.text = TowerHealth.ToString();
    }
    public void DecreaseHealth(float hit)
    {
        TowerHealth -= hit;
        Score.text = TowerHealth.ToString();
    }
    public void IncreaseHealth(float hit)
    {
        TowerHealth += hit;
        Score.text = TowerHealth.ToString();
    }
    public bool IsDead()
    {
        if (TowerHealth <= 0 || isChanged)
        {
            Change();
            return true;
        }
        return false;
    }
    void Start()
    {
        Direction = HomeBase.position - transform.position;
        projectile = FindObjectOfType<Projectile>();
        Vector3.Normalize(Direction);
        SetScore();
    }

    void Update()
    {
        if (!Home.IsDead()&&!isChanged)
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        projectile.Shoot();
        collide = Physics2D.Raycast(transform.position, Direction);
        if (collide.collider != null && Time.time > nextFire)
        {
            OperationsAttack();
            nextFire = Time.time + fireRate;
        }
    }

    public void TowerDecreaseHealth(float hit)
    {
        TowerHealth = TowerHealth - hit;
    }

    public void OperationsAttack()
    {
        Home.DecreaseHealth(Damage);
        if (Home.IsDead())
        {
            Home.Destroy();
        }
    }

    public void Change()
    {
        isChanged = true;
        projectile.Return();
        Sprite.sprite = HomeSprite;
    }
}