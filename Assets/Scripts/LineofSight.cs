using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Following Code is based of YouTube Tutorial - Sebastian Lague

public class LineofSight : MonoBehaviour
{
    [Range(0,360)]
    public float angle;
    private Transform player;
    public float radius;
    public float rotTime;
    public List<Transform> visibleTargets;
    public static bool Lost = false;
    private bool canLose = true;
    public float meshRes;
    public MeshFilter viewMeshFilter;
    private Mesh viewMesh;
    public LayerMask target, obstacles;
    //private GameObject player;
    private GameObject eventSystem;
    private bool runOnce = true;
    public static int AmountOfTimesCaptured;
    public void Start()
    {
        eventSystem = GameObject.Find("EventSystem");
        StartCoroutine(nameof(FindTargets), 0.2f);
        runOnce = true;
        canLose = true;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        viewMesh = new Mesh
        {
            name = "View Mesh"
        };
        viewMeshFilter.mesh = viewMesh;
    }

    IEnumerator FindTargets(float Delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(Delay);
            FindVisibletargets();
        }
    }

    private void LateUpdate() => DrawFOV();

    ViewCastInfo ViewCast(float globalangle)
    {
        Vector3 dir = DirOfAngle(globalangle, true);

        if (Physics.Raycast(transform.position, dir, out RaycastHit hit, radius, obstacles))
        {
            return new ViewCastInfo(true, hit.point, hit.distance, globalangle);
        }
        else
        {
            return new ViewCastInfo(false, transform.position + dir * radius, radius, globalangle);
        }
    }

    public Vector3 DirOfAngle(float angleDegrees, bool angleGlobal)
    {
        if (!angleGlobal)
        {
            angleDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleDegrees * Mathf.Deg2Rad));
    }
    
    void FindVisibletargets()
    {
        visibleTargets.Clear();
        Collider[] TargetsInFov = Physics.OverlapSphere(transform.position, radius, target);
        for(int i = 0; i<TargetsInFov.Length; i++)
        {
            Transform target = TargetsInFov[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            if(Vector3.Angle(transform.forward, dirToTarget) < angle / 2){
                float dist = Vector3.Distance(transform.position, target.position);
                if(!Physics.Raycast(transform.position, dirToTarget, dist, obstacles) && !Movement.PlayerIsInvisible)
                {
                    //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(player.position - transform.position), rotTime);
                    visibleTargets.Add(target);
                    if (canLose)
                    {
                        transform.LookAt(player);
                        AmountOfTimesCaptured++;
                        PlayerPrefs.SetInt("AmountOfTimesCaptured", AmountOfTimesCaptured);
                        PlayerPrefs.Save();
                        print("Only Run Once Plaese");
                        StartCoroutine(nameof(RunOnce), 0.1f);
                        canLose = false;
                    }
                }
            }
        }

    }
    IEnumerator RunOnce(float dlay)
    {
        yield return new WaitForSeconds(dlay);
        Lost = true;
    }




    void DrawFOV()
    {
        int stepCount = Mathf.RoundToInt(angle * meshRes);
        float stepAngleSize = angle / stepCount;
        List<Vector3> ViewPoints = new();
        for (int i=0; i< stepCount; i++)
        {
            float ang = transform.eulerAngles.y - angle / 2 + stepAngleSize * i;
            ViewCastInfo newViewCast = ViewCast(ang);
            ViewPoints.Add(newViewCast.point);
        }
        int vertexCount = ViewPoints.Count + 1;
        Vector3[] vert = new Vector3[vertexCount];
        int[] tris = new int[(vertexCount - 2) * 3];
        vert[0] = Vector3.zero;
        for(int i = 0; i<vertexCount-1; i++)
        {
            vert[i + 1] = transform.InverseTransformPoint(ViewPoints[i]);
            if (i < vertexCount - 2)
            {
                tris[i * 3] = 0;
                tris[i * 3 + 1] = i + 1;
                tris[i * 3 + 2] = i + 2;
            }
        }
        viewMesh.Clear();
        viewMesh.vertices = vert;
        viewMesh.triangles = tris;
        viewMesh.RecalculateNormals();
    }

    public struct ViewCastInfo
    {
        public bool hit;
        public Vector3 point;
        public float dst, angle;

        public ViewCastInfo(bool _hit, Vector3 _point, float _dst, float _angle)
        {
            hit = _hit;
            point = _point;
            dst = _dst;
            angle = _angle;
        }
    }
}
