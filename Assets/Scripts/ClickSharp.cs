using System;
using UnityEngine;

public class ClickSharp : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private Vector3 _jumpDirection;
    private Rigidbody _rigidbody;

    public Clickable clickable;
    public Resources resources;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        Jump();
    }

    public void SetVisual(Material material, Mesh mesh)
    {
        GetComponent<Renderer>().material = material;
        GetComponent<MeshFilter>().mesh = mesh;
    }

    private void Jump()
    {
        _jumpDirection = new Vector3
            (
            UnityEngine.Random.Range(-0.75f, 0.75f),
            1,
            UnityEngine.Random.Range(-0.15f, 0.75f)
            );

        _rigidbody.AddForce(_jumpDirection * _jumpForce);
    }

    private void OnMouseEnter()
    {
        resources.CollectCoins(clickable.coinsPerClick, transform.position);
        Destroy(gameObject);
    }
}