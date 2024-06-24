using UnityEngine;
using UnityEngine.SceneManagement;
public class Offense : MonoBehaviour
{
     
    public Draw draw;
    Vector3 CurrentPos;
    int moveIndex = 0;
    Vector3 OriginalPos;
    public Level_1 level_1;

    private void Start()
    {
        Debug.Log(SceneManager.GetActiveScene().name);
        OriginalPos = gameObject.transform.position;
    }

    private void Update()
    {
        if (draw.TargetSelected)
        {
            Move();
        }
    }

    public void Move(){
        CurrentPos = draw.Positions[moveIndex];
        gameObject.transform.position = Vector2.MoveTowards(
            gameObject.transform.position,
            CurrentPos,
            2 * Time.deltaTime
        );
        if (Vector3.Distance(CurrentPos, gameObject.transform.position) <= 0.05f)
        {
            moveIndex++;
        }
        if (moveIndex > draw.Positions.Length - 1)
        {
            level_1.AttackOnTower(CurrentPos);
            gameObject.transform.position = OriginalPos;
            moveIndex = 0;
        }
    }
}
