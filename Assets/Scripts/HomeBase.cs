using UnityEngine;
using UnityEngine.UI;

public class HomeBase : MonoBehaviour
{
    private float Defense = 100f;
    public Text Score;
    private void Start() 
    {
        SetScore();
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void SetScore()
    {
        Score.text = Defense.ToString();
    }

    public Vector3 GetVector3()
    {
        return transform.position;
    }

    public void DecreaseHealth(float hit)
    {
        Defense -= hit;
        Score.text = Defense.ToString();
    }

    public bool IsDead()
    {
        if (Defense < 0)
        {
            return true;
        }
        return false;
    }
}
