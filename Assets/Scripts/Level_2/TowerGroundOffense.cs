using UnityEngine;

public class TowerGroundOffense : MonoBehaviour 
{
    public int Health; 
    public Vector3 target;
    public Vector3 origin;
    public HomeBase home;
    float speed;
    public Level_1 level_1;
    public void Destroy(){
        Destroy(gameObject);
    }
    public bool IsDead(){
        if(Health<0){
            return true; 
        }
        return false; 
    }
    public void DecreaseHealth(int hit){
        Health = Health- hit; 
    }
    private void Start() {
        origin = transform.position;
        target = home.GetVector3();
        speed = Time.deltaTime;    
    }
    public void Return()
    {
        transform.position = origin;
    }
    public void Move()
    {
        if (!home.IsDead()&&level_1.OpsFinish)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed);
            if (Vector3.Distance(transform.position, target) < 0.0001f)
            {
                home.DecreaseHealth(2f);
                Return();
            }
        }
    }
    private void Update() 
    {

        Move();
    }
}