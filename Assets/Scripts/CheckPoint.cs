using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public bool checkpointActivo = false;
    public Sprite spriteActivo;
    private SpriteRenderer SpriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void OnTgerEnter2D(Collider2D collsion){
        if (collision.CompareTag("Player")&& !checkpointActivo){
            ActivarCheckpoint();
        }
    }

    void ActivarCheckpoint(){
        
    }
}
