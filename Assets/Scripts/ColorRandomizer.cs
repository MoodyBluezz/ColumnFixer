using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ColorRandomizer : MonoBehaviour
{
    public List<GameObject> columnsList = new List<GameObject>();
    public List<Color> colorsList = new List<Color>();
    public List<GameObject> changedColorColumnsList = new List<GameObject>();
    public float _currentTime { get; set; } = 0;
    private const float _fixedTime = 5f;

    private void Update()
    {
        _currentTime += 1f * Time.deltaTime;
        if (!(_currentTime >= _fixedTime)) return;
        RandomizeColumnsColor();
        _currentTime = 0;
    }

    private void RandomizeColumnsColor()
    {
        var randomGameObjectIndex = Random.Range(0, columnsList.Count);
        var randomColor = Random.Range(0, colorsList.Count);
        columnsList[randomGameObjectIndex].GetComponent<Renderer>().material.color = colorsList[randomColor];
        changedColorColumnsList.Add(columnsList[randomGameObjectIndex]);
    }
}
