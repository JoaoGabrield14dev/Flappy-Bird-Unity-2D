using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Camera))]
public class AspectRatioController : MonoBehaviour
{
    private Camera cam;
    private static Camera backgroundCam;

    [Header("Aspect Ratio Target")]
    [SerializeField] private float targetAspect = 4f / 3f; // 4:3 (1024x768)

    [Header("UI Reference Resolution")]
    [SerializeField] private Vector2 referenceResolution = new Vector2(1024f, 768f);

    private int lastWidth = -1;
    private int lastHeight = -1;

    private void Awake()
    {
        cam = GetComponent<Camera>();
        EnsureBackgroundCamera();
        AplicarProporcaoEConfigurarCanvas();
    }

    private void Start()
    {
        AplicarProporcaoEConfigurarCanvas();
    }

    private void Update()
    {
        if (Screen.width != lastWidth || Screen.height != lastHeight)
        {
            AplicarProporcaoEConfigurarCanvas();
        }

        VerificarAtalhoFullscreen();
    }

    private void AplicarProporcaoEConfigurarCanvas()
    {
        lastWidth = Screen.width;
        lastHeight = Screen.height;

        AjustarProporcaoCamera();
        ConfigurarCanvases();
    }

    private void AjustarProporcaoCamera()
    {
        if (cam == null) return;

        float windowAspect = (float)Screen.width / Screen.height;
        float scaleHeight = windowAspect / targetAspect;

        if (scaleHeight < 1f)
        {
            cam.rect = new Rect(0f, (1f - scaleHeight) / 2f, 1f, scaleHeight);
        }
        else
        {
            float scaleWidth = 1f / scaleHeight;
            cam.rect = new Rect((1f - scaleWidth) / 2f, 0f, scaleWidth, 1f);
        }
    }

    private void EnsureBackgroundCamera()
    {
        if (backgroundCam == null)
        {
            GameObject bgObj = GameObject.Find("_AspectRatioBackgroundCamera");
            if (bgObj != null)
            {
                backgroundCam = bgObj.GetComponent<Camera>();
            }
        }

        if (backgroundCam == null)
        {
            GameObject bgObj = new GameObject("_AspectRatioBackgroundCamera");
            backgroundCam = bgObj.AddComponent<Camera>();
            backgroundCam.depth = cam != null ? cam.depth - 10 : -100;
            backgroundCam.clearFlags = CameraClearFlags.SolidColor;
            backgroundCam.backgroundColor = Color.black;
            backgroundCam.cullingMask = 0; // Não renderiza nenhum objeto da cena, apenas a cor preta
            backgroundCam.rect = new Rect(0f, 0f, 1f, 1f);
            DontDestroyOnLoad(bgObj);
        }
        else if (cam != null)
        {
            backgroundCam.depth = cam.depth - 10;
        }
    }

    private void ConfigurarCanvases()
    {
        Canvas[] canvases = FindObjectsByType<Canvas>(FindObjectsInactive.Include);
        foreach (Canvas canvas in canvases)
        {
            canvas.renderMode = RenderMode.ScreenSpaceCamera;
            canvas.worldCamera = cam;
            canvas.planeDistance = 10f;
            canvas.sortingOrder = 100; 

            CanvasScaler scaler = canvas.GetComponent<CanvasScaler>();
            if (scaler != null)
            {
                scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
                scaler.referenceResolution = referenceResolution;
                scaler.screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
                scaler.matchWidthOrHeight = 0.5f;
            }
        }
    }

    private void VerificarAtalhoFullscreen()
    {
        if (Keyboard.current != null)
        {
            if (Keyboard.current.f4Key.wasPressedThisFrame || Keyboard.current.f11Key.wasPressedThisFrame)
            {
                Screen.fullScreen = !Screen.fullScreen;
            }
        }
    }
}
