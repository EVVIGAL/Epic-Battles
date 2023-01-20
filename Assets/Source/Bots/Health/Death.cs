using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour, IDeath
{
    [SerializeField] private float _colorChangeSpeed = 1f;
    [SerializeField] private float _fallingSpeed = 5f;
    [SerializeField] private float _waitBeforeFall = 3f;
    [SerializeField] private float _destroyTime = 10f;
    [SerializeField] private Color _deathColor = Color.gray;

    private List<Material> _materials = new();

    private void Init()
    {
        MeshRenderer[] meshes = GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer meshRenderer in meshes)
            _materials.AddRange(meshRenderer.materials);

        SkinnedMeshRenderer[] skinnedMeshRenderers = GetComponentsInChildren<SkinnedMeshRenderer>();
        foreach (SkinnedMeshRenderer skinnedMeshRenderer in skinnedMeshRenderers)
            _materials.AddRange(skinnedMeshRenderer.materials);
    }

    public void Die()
    {
        Init();
        StartCoroutine(SwitchColor());
        StartCoroutine(Fell());
        Destroy(gameObject, _destroyTime);
    }

    private IEnumerator SwitchColor()
    {
        while(_materials[0].color != _deathColor)
        {
            foreach (Material material in _materials)
                material.color = Color.Lerp(material.color, _deathColor, Time.deltaTime * _colorChangeSpeed);

            yield return null;
        }
    }

    private IEnumerator Fell()
    {
        yield return new WaitForSeconds(_waitBeforeFall);

        OnFell();
        while (true)
        {
            transform.position += Vector3.down * _fallingSpeed * Time.deltaTime;
            yield return null;
        }
    }

    protected virtual void OnFell() { }
}