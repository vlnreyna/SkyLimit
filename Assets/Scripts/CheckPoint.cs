/*using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public bool checkpointActivo = false;
    public sprite spriteActivo;
    private spriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<spriteRenderer>();
    }

    // Update is called once per frame
    private void OnTgerEnter2D(Collider2D collision){
        if (collision.CompareTag("Player")&& !checkpointActivo){
            ActivarCheckpoint();
        }
    }

    void ActivarCheckpoint(){
        if(GameManager.Instance != null){
            GameManager.Instance.ActualizarCheckpoint(transform.position, this);
        }
        checkpointActivo = true;

        if(spriteRenderer != null && spriteActivo != null){
            spriteRenderer.sprite = spriteActivo;
        }
    }
}*/

using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public Sprite spriteActivado;

    private SpriteRenderer spriteRenderer;
    private bool activado;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (activado) return;

        PlayerRespawn jugador = other.GetComponentInParent<PlayerRespawn>();

        if (jugador == null) return;

        jugador.EstablecerCheckpoint(transform.position);
        activado = true;

        if (spriteRenderer != null && spriteActivado != null)
        {
            spriteRenderer.sprite = spriteActivado;
        }
    }
}
