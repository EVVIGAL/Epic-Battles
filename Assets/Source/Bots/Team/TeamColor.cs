using System;
using UnityEngine;

public class TeamColor : MonoBehaviour
{
    private Material _teamColor;
    private const string TeamMaterial = "TeamColor (Instance)";

    public Material ColorOfTeam => _teamColor;

    private void Awake()
    {
        _teamColor = transform.parent.GetComponent<Team>().Material;

        if (_teamColor == null)
            throw new InvalidOperationException("Team material not found on parent transform!");

        MeshRenderer[] meshes = GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer meshRenderer in meshes)
        {
            Material[] materials = meshRenderer.materials;
            for (int i = 0; i < materials.Length; i++)
                if (materials[i].name == TeamMaterial)
                    materials[i] = _teamColor;
            meshRenderer.materials = materials;
        }

        SkinnedMeshRenderer[] skinnedMeshRenderers = GetComponentsInChildren<SkinnedMeshRenderer>();
        foreach (SkinnedMeshRenderer skinnedMeshRenderer in skinnedMeshRenderers)
        {
            Material[] materials = skinnedMeshRenderer.materials;
            for (int i = 0; i < materials.Length; i++)
                if (materials[i].name == TeamMaterial)
                   materials[i] = _teamColor;
            skinnedMeshRenderer.materials = materials;
        }
    }
}