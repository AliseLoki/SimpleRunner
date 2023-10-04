using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private HeartPumpkin _heartPumpkinPrefab;

    private List<HeartPumpkin> _heartPumpkinList = new List<HeartPumpkin>();

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int value)
    {
        if (_heartPumpkinList.Count < value)
        {
            var difference = value - _heartPumpkinList.Count;

            for (int i = 0; i < difference; i++)
            {
                CreateHeartPumpkin();
            }
        }
        else if (_heartPumpkinList.Count > value && _heartPumpkinList.Count != 0)
        {
            var difference = _heartPumpkinList.Count - value;

            for (int i = 0; i < difference; i++)
            {
                DestroyHeartPumpkin(_heartPumpkinList[_heartPumpkinList.Count - 1]);
            }
        }
    }

    private void DestroyHeartPumpkin(HeartPumpkin heartPumpkin)
    {
        _heartPumpkinList.Remove(heartPumpkin);
        heartPumpkin.ToEmpty();
    }

    private void CreateHeartPumpkin()
    {
        HeartPumpkin heartPumpkin = Instantiate(_heartPumpkinPrefab, transform);
        _heartPumpkinList.Add(heartPumpkin.GetComponent<HeartPumpkin>());
        heartPumpkin.ToFill();
    }
}
