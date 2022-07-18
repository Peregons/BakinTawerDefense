using System.Collections;
using System.Collections.Generic;
using Towers;
using UnityEngine;

[CreateAssetMenu(fileName = "TowerData", menuName = "ScriptableObjects/TowerData", order = 1)]
public class TowerData : ScriptableObject
{
    [SerializeField] private string _title;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Sprite _portrait;

    public string title => _title;
    public GameObject prefab => _prefab;
    public Sprite portrait => _portrait;
}