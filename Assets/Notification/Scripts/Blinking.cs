using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Blinking : MonoBehaviour
{
    private Image _img;
    void Start()
    {
        _img = GetComponent<Image>();

        if (_img)
        {
            StartCoroutine("Blink");
        }
    }

    IEnumerator Blink()
    {
        Color initialColor = new Color(_img.color.r, _img.color.g, _img.color.b, _img.color.a);
        Color transparentColor = new Color(_img.color.r, _img.color.g, _img.color.b, 0);
        for (int i = 0; i < 6; i++)
        {
            yield return new WaitForSeconds(0.3f);
            _img.color = transparentColor;
            yield return new WaitForSeconds(0.3f);
            _img.color = initialColor;
        }
    }
}
