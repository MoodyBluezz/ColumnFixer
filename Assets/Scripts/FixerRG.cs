using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FixerRG : MonoBehaviour
{
    public ColorRandomizer _colorRandomizer;
    public List<Image> fixerSkills = new List<Image>();
    private Vector3 previousPos;
    private bool _isCollided = false;

    private void Start()
    {
        previousPos = transform.position;
    }

    private void FixedUpdate()
    {
        FixColumnColor();
    }

    private void FixColumnColor()
    {
        if (!_isCollided)
        {
            foreach (var column in _colorRandomizer.changedColorColumnsList)
            {
                var columnColor = column.GetComponent<Renderer>().material.color;
                if (columnColor.Equals(fixerSkills[0].color) || columnColor.Equals(fixerSkills[1].color))
                {
                    transform.position = Vector3.Lerp(transform.position,
                        new Vector3(column.transform.position.x, 0, column.transform.position.z), 1f * Time.deltaTime);
                }
            }
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position,
                previousPos, 2f * Time.deltaTime);
            StartCoroutine(WaitForFixerToReturn());
        }
    }

    private IEnumerator WaitForFixerToReturn()
    {
        yield return new WaitForSeconds(2);
        _colorRandomizer._currentTime = 0;
        _isCollided = false;
        _colorRandomizer.changedColorColumnsList.Clear();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.tag.Equals("Cube")) return;
        _isCollided = true;
        other.GetComponent<Renderer>().material.color = Color.white;
    }
}