using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 target;
    public Vector3 origin;
    public HomeBase home;
    double speed;

    private void Start()
    {
        home = FindObjectOfType<HomeBase>();
        origin = transform.position;
        target = home.GetVector3();
        speed = 1.5*Time.deltaTime;
    }
    public void Return()
    {
        transform.position = origin;
    }
    
    public void Shoot()
    {
        if (!home.IsDead())
        {
            transform.position = Vector3.MoveTowards(transform.position, target, (float)speed);
            if (Vector3.Distance(transform.position, target) < 0.0001f)
            {
                Return();
            }
        }
    }
    public void Destroy(){
        Destroy(gameObject);
    }
}
