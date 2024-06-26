using UnityEngine;

public class Level_1 : MonoBehaviour
{
    private Vector3[] TowerPos = new Vector3[1];
    public TowerGroundOffense[] groundOffenses;
    public TowerGunScript[] towerGuns;
    public bool OpsFinish = false;  
    public void turn(){
        OpsFinish = false;
    }
    public bool StopProjectile()
    {
        if (towerGuns[0].isDead)
        {
            return true;
        }
        return false;
    }
    public bool TargetReached(Vector3 End)
    {
        if (
            Vector3.Distance(End, towerGuns[0].GetPos()) <= 0.5f
        )
        {
            return true;
        }
        return false;
        // if (
        //     Vector3.Distance(End, towerGuns[0].GetPos()) <= 0.5f
        //     || Vector3.Distance(End, towerGuns[1].GetPos()) <= 0.5f
        // )
        // {
        //     return true;
        // }
        // return false;
    }

    private void Start()
    {
        TowerPos[0] = towerGuns[0].GetPos();
        //TowerPos[1] = towerGuns[1].GetPos();
    }
    public void AttackOnGroundTower(Vector3 hitPos)
    {
        if (Vector3.Distance(hitPos, TowerPos[1]) <= 0.5f)
        {
            if (groundOffenses[0].IsDead())
            {
                OpsFinish = true;
                groundOffenses[0].Destroy();
                //towerGuns[0].IncreaseHealth(2);
            }
            if (!groundOffenses[0].IsDead())
            {
                groundOffenses[0].DecreaseHealth(2);
            }
        }
        // if (Vector3.Distance(hitPos, TowerPos[1]) <= 0.5f)
        // {
        //     if (towerGuns[1].IsDead())
        //     {
        //         towerGuns[1].IncreaseHealth(2);
        //     }
        //     if (!towerGuns[1].IsDead())
        //     {
        //         towerGuns[1].DecreaseHealth(2);
        //     }
        // }
    }
    public void AttackOnTower(Vector3 hitPos)
    {
        if (Vector3.Distance(hitPos, TowerPos[0]) <= 0.5f)
        {
            if (towerGuns[0].IsDead())
            {
                OpsFinish = true;
                towerGuns[0].Destroy();
                //towerGuns[0].IncreaseHealth(2);
            }
            if (!towerGuns[0].IsDead())
            {
                towerGuns[0].DecreaseHealth(2);
            }
        }
        // if (Vector3.Distance(hitPos, TowerPos[1]) <= 0.5f)
        // {
        //     if (towerGuns[1].IsDead())
        //     {
        //         towerGuns[1].IncreaseHealth(2);
        //     }
        //     if (!towerGuns[1].IsDead())
        //     {
        //         towerGuns[1].DecreaseHealth(2);
        //     }
        // }
    }
}
