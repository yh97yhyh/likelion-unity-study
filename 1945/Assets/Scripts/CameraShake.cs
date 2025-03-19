using Unity.Cinemachine;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance;
    private CinemachineImpulseSource impulseSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    void Update()
    {
        
    }

    public void ShakeCamera() // Camera Shake
    {
        if (impulseSource != null)
        {
            impulseSource.GenerateImpulse();
            print("Shake Camera");
        }
    }
}
