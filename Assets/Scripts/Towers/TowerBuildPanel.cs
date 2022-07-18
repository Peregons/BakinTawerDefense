using System;
using UnityEngine;

namespace Towers
{
    public class TowerBuildPanel : MonoBehaviour
    {
        [SerializeField] private TowerData[] towersData;
        [SerializeField]  private TowerItem _towerItemTemplate;
        [SerializeField]  private RectTransform _rectTransform;
        [SerializeField]  private Camera _camera;
        public static event Action OnShow;
        public static event Action OnHide;
        public TowerPlace _selectedTowerPlace;
        private void Awake()
        {
            TowerPlace.OnClick += Show;
            TowerItem.OnClick += BuildTower;

            _camera = Camera.main;
            _rectTransform = GetComponent<RectTransform>();
            _towerItemTemplate.gameObject.SetActive(false);
            foreach (var towerData in towersData)
                Instantiate(_towerItemTemplate, _towerItemTemplate.transform.parent).Initialize(towerData);

            gameObject.SetActive(false);
        }

        private void BuildTower(GameObject prefab)
        {
            _selectedTowerPlace.SetColliderActive(false);
            var placeTransform = _selectedTowerPlace.transform;
            Instantiate(prefab, placeTransform, false);
            Hide();
        }

        private void OnDestroy()
        {
            TowerPlace.OnClick -= Show;
        }

        public void Show(TowerPlace place)
        {
            gameObject.SetActive(true);
            _rectTransform.anchoredPosition = _camera.WorldToScreenPoint(place.transform.position);
            _selectedTowerPlace = place;
            OnShow?.Invoke();
        }

        public void Hide()
        {
            gameObject.SetActive(false);
            OnHide?.Invoke();
        }
    }
}