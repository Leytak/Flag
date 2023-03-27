using System;
using UnityEngine;

public class FlagCPU : Flag
{
    [SerializeField]
    [Range(0, 1)]
    private float amplitude = 1f;
    [SerializeField]
    [Range(0, 1)]
    private float frequency = 1f;
    [SerializeField]
    [Range(0, 1)]
    private float waveSpeed = 1f;
    [SerializeField]
    [Range(0, 1)]
    private float shiftSpeed = 1f;

    private void Update()
    {
        ShiftUV();
        UpdateWave();
    }

    private void ShiftUV()
    {
        var uv = meshFilter.mesh.uv;
        for (int i = 0; i < uv.Length; i++)
            uv[i].x += shiftSpeed * Time.deltaTime;
        meshFilter.mesh.uv = uv;
    }

    private void UpdateWave()
    {
        var vertices = meshFilter.mesh.vertices;
        for (int i = 0; i < vertices.Length; i++)
        {
            var x = vertices[i].x / gridSize.x;
            var z = amplitude * Mathf.Sin((x - waveSpeed * Time.time) / frequency);
            vertices[i].z = z * x;
        }
        meshFilter.mesh.vertices = vertices;
    } 
}