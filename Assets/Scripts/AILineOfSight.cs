using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AILineOfSight : MonoBehaviour
{
    public float dist = 10, angle = 30, height = 1;
    public Color color;
    Mesh mesh;
    Mesh CreateMesh()
    {
        Mesh mesh = new();

        int numTriangles = 8;
        int NumVert = numTriangles * 3;

        Vector3[] vertices = new Vector3[NumVert];
        int[] triangles = new int[NumVert];

        Vector3 CentreBot = Vector3.zero;
        Vector3 LeftBot = Quaternion.Euler(0, -angle, 0) * Vector3.forward * dist;
        Vector3 RightBot = Quaternion.Euler(0, angle, 0) * Vector3.forward * dist;
        Vector3 CentreTop = CentreBot + Vector3.up * height;
        Vector3 RightTop = RightBot + Vector3.up * height;
        Vector3 LeftTop = LeftBot + Vector3.up * height;

        int vert = 0;

        //Left side
        vertices[vert++] = CentreBot;
        vertices[vert++] = LeftBot;
        vertices[vert++] = LeftTop;

        vertices[vert++] = LeftTop;
        vertices[vert++] = CentreTop;
        vertices[vert++] = CentreBot;
        //right side
        vertices[vert++] = CentreBot;
        vertices[vert++] = CentreTop;
        vertices[vert++] = RightTop;

        vertices[vert++] = RightTop;
        vertices[vert++] = RightBot;
        vertices[vert++] = CentreBot;
        //far side
        vertices[vert++] = LeftBot;
        vertices[vert++] = RightBot;
        vertices[vert++] = RightTop;

        vertices[vert++] = RightTop;
        vertices[vert++] = LeftTop;
        vertices[vert++] = LeftBot;
        //top
        vertices[vert++] = CentreTop;
        vertices[vert++] = LeftTop;
        vertices[vert++] = RightTop;
        //bottom
        vertices[vert++] = CentreBot;
        vertices[vert++] = RightBot;
        vertices[vert++] = LeftBot;

        for (int i = 0; i < NumVert; i++)
        {
            triangles[i] = i;
        }
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();


        return mesh;
    }
    private void OnValidate()
    {
        mesh = CreateMesh();

    }
    private void OnDrawGizmos()
    {
        if (mesh)
        {
            Gizmos.color = color;
            Gizmos.DrawMesh(mesh, transform.position, transform.rotation);
        }
    }
}
