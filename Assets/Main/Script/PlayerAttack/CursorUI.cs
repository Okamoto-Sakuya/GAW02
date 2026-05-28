using UnityEngine;
using UnityEngine.UI;

public class CursorUI : MonoBehaviour
{
    public RectTransform cursorImage;

    void Update()
    {
        cursorImage.position = Input.mousePosition;
    }
}