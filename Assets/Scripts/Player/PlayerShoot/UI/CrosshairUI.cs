using UnityEngine;

public class CrosshairUI : MonoBehaviour
{
    [SerializeField] private Vector3 crosshairNormal;
    [SerializeField] private Vector3 crosshairBig;
    
    [SerializeField] private float timeCrosshair;
    
    private RectTransform _crosshair;
    
    private void Awake()
    {
        _crosshair = GetComponent<RectTransform>();
    }

    public void OnShoot()
    {
        _crosshair.localScale = crosshairBig;
        
        Invoke("SizeCrosshair", timeCrosshair);
    }

    private void SizeCrosshair()
    {
        _crosshair.localScale = crosshairNormal;
    }
}
