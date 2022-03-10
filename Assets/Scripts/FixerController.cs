using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class FixerController : MonoBehaviour
{
    public ColorRandomizer _colorRandomizer;
    public List<Image> fixerSkills = new List<Image>();

	protected abstract void FixColumnColor();
    protected abstract IEnumerator WaitForFixerToReturn();
}
