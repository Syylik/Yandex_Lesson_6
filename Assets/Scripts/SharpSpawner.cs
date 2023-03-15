using UnityEngine;

public class SharpSpawner : MonoBehaviour
{
    [SerializeField] private ClickSharp _sharpPrefab;
    [SerializeField] private Transform _sharpSpawnPos;
    [SerializeField] private ModelVariants _variants;
    [SerializeField] private MaterialManager _materialManager;
    [SerializeField] private Clickable _clickable;
    [SerializeField] private Resources _resources;

    private void OnEnable() => _clickable.OnClick += SpawnSharps;

    public void SpawnSharps()
    {
        for(int i = 0; i < _clickable.coinsPerClick; i++)
        {
            var sharp = Instantiate(_sharpPrefab, _sharpSpawnPos.position, Quaternion.identity);
            sharp.SetVisual(_materialManager.GetMaterial(), _variants.GetMesh());
            sharp.resources = _resources;
            sharp.clickable = _clickable;
        }
    }

    private void OnDisable() => _clickable.OnClick -= SpawnSharps;
}
