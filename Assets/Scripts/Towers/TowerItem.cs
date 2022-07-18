using System;
using TMPro;
using Towers;
using UnityEngine;
using UnityEngine.UI;

public class TowerItem : MonoBehaviour
{
    [SerializeField] private Image _portrait;
    [SerializeField] private TextMeshProUGUI _title;
    private GameObject _towerPrefab;
    public static event Action<GameObject> OnClick;

    public void Initialize(TowerData data)
    {
        _towerPrefab = data.prefab;
        _portrait.sprite = data.portrait;
        _title.text = data.title;
        gameObject.SetActive(true);
    }

    public void Click()
    {
        OnClick?.Invoke(_towerPrefab);
    }
}