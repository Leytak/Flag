using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public abstract class Flag : MonoBehaviour
{
    [SerializeField] protected Vector2Int gridSize;

    protected MeshFilter meshFilter;
    
    private void Awake()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshFilter.mesh = MeshGenerator.GeneratePlane(gridSize);
    }

    private void OnDrawGizmos()
    {
        if (meshFilter == null
            || meshFilter.mesh == null
            || meshFilter.mesh.vertices == null)
            return;

        foreach (var vertex in meshFilter.mesh.vertices)
        {
            Gizmos.DrawSphere(transform.position + vertex, 0.05f);
        }
    }
}
