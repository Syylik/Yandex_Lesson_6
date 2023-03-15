using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Clickable : MonoBehaviour
{

    [SerializeField] private AnimationCurve _scaleCurve;
    [SerializeField] private float _scaleTime = 0.25f;
    [SerializeField] private HitEffect _hitEffectPrefab;
    [SerializeField] private Resources _resources;

    public event Action OnClick;

    public int coinsPerClick = 1;

    // ����� ���������� �� Interaction ��� ����� �� ������
    public void Hit()
    {
        OnClick?.Invoke();
        HitEffect hitEffect = Instantiate(_hitEffectPrefab, transform.position, Quaternion.identity);
        hitEffect.Init(coinsPerClick);
        StartCoroutine(HitAnimation());
    }

    // �������� ��������� ����
    private IEnumerator HitAnimation()
    {
        for (float t = 0; t < 1f; t += Time.deltaTime / _scaleTime)
        {
            float scale = _scaleCurve.Evaluate(t);
            transform.localScale = Vector3.one * scale;
            yield return null;
        }
        transform.localScale = Vector3.one;
    }

    // ���� ����� ����������� ���������� �����, ���������� ��� �����
    public void AddCoinsPerClick(int value)
    {
        coinsPerClick += value;
    }

}
