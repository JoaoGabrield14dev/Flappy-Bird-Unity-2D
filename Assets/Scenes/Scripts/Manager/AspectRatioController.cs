using UnityEngine;

public class AspectRatioController : MonoBehaviour
{
    private Camera cam;

    private const float TARGET_ASPECT = 4f / 3f;

    private void Awake()
    {
        cam = GetComponent<Camera>();
        AjustarProporcao();
    }

    private void Update()
    {
        AjustarProporcao();
    }

    private void AjustarProporcao()
    {
        float windowAspect = (float)Screen.width / Screen.height;
        float scaleHeight = windowAspect / TARGET_ASPECT;

        if (scaleHeight < 1f)
        {
            cam.rect = new Rect(0f,(1f - scaleHeight) / 2f, 1f,scaleHeight);
        }
        else
        {
            float scaleWidth = 1f / scaleHeight;
            cam.rect = new Rect((1f - scaleWidth) / 2f,0f,scaleWidth,1f);
        }
    }
}
