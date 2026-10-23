using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static GameManager Instance;

    [Header("CheckPoint")]
    public Vector3 checkpointPosicion;
    private CheckPoint checkpointActual;

    void Start(){

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player != null){
            checkpointPosicion = player.transform.position;
        }
    }

    public void IrAlMenu(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void ActivarCheckpoint(Vector3 nuevaPosicion, CheckPoint nuevoCheckpoint){
        checkpointPosicion = nuevaPosicion;
        checkpointActual = nuevoCheckpoint;
    }

    public void RespawnJugador(){
        StartCoroutine(RespawnCoroutine());
    }

    IEnumerator RespawnCoroutine(){
        yield return new WaitForSeconds(1f);
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player != null){
            player.GetComponent<PlayerRespawn>().Reaparecer();
        }
    }
}
