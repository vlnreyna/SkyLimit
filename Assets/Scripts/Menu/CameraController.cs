using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform objetivo;
    public float speedCamera = 0.025f;
    public Vector3 displacement;

    private float alturaMaxima;

    private void Start()
    {
        alturaMaxima = transform.position.y;
    }

    private void LateUpdate()
    {
        Vector3 desiredPosition = objetivo.position + displacement;

        if (desiredPosition.y > alturaMaxima)
        {
            alturaMaxima = desiredPosition.y;
        }

        desiredPosition.y = alturaMaxima;

        transform.position = Vector3.Lerp(transform.position, desiredPosition, speedCamera);
    }

    public void ReiniciarEn(Vector3 posicion)
    {
        Vector3 nuevaPosicion = posicion + displacement;
        alturaMaxima = nuevaPosicion.y;
        transform.position = nuevaPosicion;
    }
}