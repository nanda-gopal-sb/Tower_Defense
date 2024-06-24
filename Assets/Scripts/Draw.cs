using UnityEngine;
public class Draw : MonoBehaviour 
{
    public Level_1 level_1;
    public LineRenderer Path;
    private Vector3 PreviousPosMouse;
    private readonly float MinDistance = 0.05f;
    public Vector3[] Positions;
    public bool TargetSelected = false;
    private void Update() 
    {
        if(level_1.OpsFinish && TargetSelected)
        {
            TargetSelected = false;
            DeleteLine();
        }
        if(Input.GetMouseButton(0)&&!TargetSelected)
        {
            LineDraw();
        }
        if (Input.GetMouseButtonUp(0))
        {
            UpdateLine();
        }
    }
    private void Start() 
    {
        Path.positionCount = 1;
    }
    
    public void UpdateLine()
    {
        Positions = new Vector3[Path.positionCount];
        Path.GetPositions(Positions);
        Debug.Log(Positions.Length);
        // if (!level_1.TargetReached(Positions[^1]))
        // {
        //     Positions = new Vector3[0];
        //     Path.positionCount = 1;
        //     TargetSelected = false;
        //     return;
        // }
        TargetSelected = true;
    }
    public void LineDraw()
    {
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        currentPosition.z = 0;
        if (Vector3.Distance(currentPosition, PreviousPosMouse) > MinDistance)
        {
            if (PreviousPosMouse == transform.position)
            {
                Path.SetPosition(0, currentPosition);
            }
            else
            {
                Path.positionCount++;
                Path.SetPosition(Path.positionCount - 1, currentPosition);
            }
            PreviousPosMouse = currentPosition;
        }
    }
    public void DeleteLine()
    {
        Path.positionCount = 0 ; 
        Positions = new Vector3[0];
        //Debug.Log(Positions);
    }
}