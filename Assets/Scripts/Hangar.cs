using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hangar : MonoBehaviour
{
    [SerializeField] private int _maxCount;
    public int Count { get => _count; }

    private int _count;

    private void Awake()
    {
        _count = Random.Range(0, _maxCount);
    }
}
