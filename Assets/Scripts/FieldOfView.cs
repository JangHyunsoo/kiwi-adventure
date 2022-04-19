using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    [SerializeField]
    private LayerMask layer_mask;
    private float fov;
    private Vector3 origin;
    private Mesh mesh;

    private void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        fov = 360f;
        origin = Vector3.zero;
    }


    private void Update()
    {
        int ray_count = 50;
        float angle = 0f;
        float angle_increase = fov / ray_count;
        float view_distance = 2f;

        Vector3[] vertices = new Vector3[ray_count + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triagles = new int[ray_count * 3];

        vertices[0] = origin;

        int vertex_index = 1;
        int triangle_index = 0;

        for(int i = 0; i <= ray_count; i++)
        {
            Vector3 vertex;
            RaycastHit2D raycast = Physics2D.Raycast(origin, Utility.GetVectorFromAngle(angle), view_distance, layer_mask);

            if (raycast.collider == null)
            {
                vertex = origin + Utility.GetVectorFromAngle(angle) * view_distance;
            }
            else
            {
                vertex = raycast.point;
                Debug.Log("°É¸²"); 
            }

            vertices[vertex_index] = vertex;

            if(i > 0)
            {
                triagles[triangle_index + 0] = 0;
                triagles[triangle_index + 1] = vertex_index - 1;
                triagles[triangle_index + 2] = vertex_index;

                triangle_index += 3;
            }
            vertex_index++;
            angle -= angle_increase;
        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triagles;
    }

    public void setOrigin(Vector3 origin)
    {
        this.origin = origin;
    }

}
