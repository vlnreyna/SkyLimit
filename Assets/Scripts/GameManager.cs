using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static GameManager Instance;

    [Header("CheckPoint")]
    public Vector3 checkpointPosicion;
    private CheckPoint checkpointActual;

    void Start(){
        if(gameOverPanel != null)
            gameOverPanel.setActive(false);
        if(reiniciarButton != null)
            reiniciarButton.onClick.AddListener(ReiniciarEscena);
        if(menuButton != null)
            menuButton.onClick.AddListener(IrAlMenu);
    }
}
