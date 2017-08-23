using UnityEngine;
using System.Collections;

public class DestroyByBullet : MonoBehaviour
{
    public GameObject explosion;
    public GameObject explosionPlayer;
    public int scoreValue;
    private GameController gameController;

    private void Start()
    {
        GameObject gameControllObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllObject != null)
        {
            gameController = gameControllObject.GetComponent<GameController>();
        }

        if (gameController == null)
        {
            Debug.Log("Can not find the script 'Game Controller'");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }

        GameObject explodedAsteroid = Instantiate(explosion, transform.position, transform.rotation) as GameObject;

        if (other.tag == "Player")
        {
            Instantiate(explosionPlayer, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }

        gameController.AddNewScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
