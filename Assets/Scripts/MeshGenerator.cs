using UnityEngine;

public static class MeshGenerator
{
    private const int TRIANGLES_PER_QUAD = 6;

    public static Mesh GeneratePlane(Vector2Int size)
    {
        var mesh = new Mesh();
        var vertices = new Vector3[(size.x + 1) * (size.y + 1)];
        var uv = new Vector2[vertices.Length];
        for (int i = 0, y = 0; y <= size.y; y++)
        {
            for (int x = 0; x <= size.x; x++)
            {
                vertices[i] = new Vector3(x, y);
                uv[i] = new Vector2(x, y) / size;
                i++;
            }
        }
        var triangles = new int[TRIANGLES_PER_QUAD * size.x * size.y];
        for (int y = 0, v = 0, t = 0; y < size.y; y++, v++)
        {
            for (int x = 0; x < size.x; x++, v++, t += TRIANGLES_PER_QUAD)
            {
                triangles[t + 0] = v + 0;
                triangles[t + 1] = v + size.x + 1;
                triangles[t + 2] = v + 1;
                triangles[t + 3] = v + 1;
                triangles[t + 4] = v + size.x + 1;
                triangles[t + 5] = v + size.x + 2;
            }
        }
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uv;
        return mesh;
    }
}
