using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FixerRB : FixerController
{
    private Vector3 lastPositionRB;
    private bool _isCollidedRB = false;

    private void Start()
    {
        lastPositionRB = new Vector3(2, 0, -1);
    }

    private void Update()
    {
        FixColumnColor();
    }

    protected override void FixColumnColor()
    {
        if (!_isCollidedRB)
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
            StartCoroutine(WaitForFixerToReturn());
            transform.position = Vector3.Lerp(transform.position,
                lastPositionRB, 2f * Time.deltaTime);
        }
    }

    protected override IEnumerator WaitForFixerToReturn()
    {
        _colorRandomizer._currentTime = 0;
        yield return new WaitForSeconds(2);
        _isCollidedRB = false;
        _colorRandomizer.changedColorColumnsList.Clear();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.tag.Equals("Cube")) return;
        _isCollidedRB = true;
        other.GetComponent<Renderer>().material.color = Color.white;
    }
}
