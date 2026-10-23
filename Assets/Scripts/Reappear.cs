using UnityEngine;

public class Reapperar : MonoBehaviour
{
        public CameraController camara;

    private Camera cam;
    private Collider2D col;
    private Rigidbody2D rb;
    private Vector3 puntoReaparicion;

    private void Start()
    {
        cam = camara.GetComponent<Camera>();
        col = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        puntoReaparicion = transform.position;
    }

    private void Update()
    {
        float bordeInferior = cam.transform.position.y - cam.orthographicSize;

        if (col.bounds.max.y < bordeInferior)
        {
            Reaparecer();
        }
    }

    public void EstablecerCheckpoint(Vector3 posicion)
    {
        puntoReaparicion = posicion;
    }

    private void Reaparecer()
    {
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;
        transform.position = puntoReaparicion;
        camara.ReiniciarEn(puntoReaparicion);
    }
}
