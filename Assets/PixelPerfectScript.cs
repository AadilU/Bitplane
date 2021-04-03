using System;
using UnityEngine;


[DisallowMultipleComponent]
[RequireComponent(typeof(Camera))]
public class PixelPerfectScript : MonoBehaviour
{

    [SerializeField]
    private int assetsPixelsPerUnit = 100;
    [SerializeField]
    private Vector2Int referenceResolution = new Vector2Int(320, 180);

    private Camera _camera;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    private void OnEnable()
    {
        UpdatePixelPerfectCameraSize();
    }

    private void LateUpdate()
    {
        UpdatePixelPerfectCameraSize();
    }

    private void UpdatePixelPerfectCameraSize()
    {
        if (!_camera || !_camera.orthographic)
            return;

        var cameraTexture = _camera.targetTexture;
        var screenWidth = cameraTexture ? cameraTexture.width : Screen.width;
        var screenHeight = cameraTexture ? cameraTexture.height : Screen.height;

        var verticalZoom = screenHeight / referenceResolution.y;
        var horizontalZoom = screenWidth / referenceResolution.x;
        var zoom = Math.Max(1, Math.Min(verticalZoom, horizontalZoom));

        var cameraOrthoSize = screenHeight * .5f / (zoom * assetsPixelsPerUnit);
        _camera.orthographicSize = cameraOrthoSize;
    }

}