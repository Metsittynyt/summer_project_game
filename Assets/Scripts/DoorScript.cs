using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    public GameObject player;
    public Sprite OpenedDoor;
    public Sprite ClosedDoor;
    public float TimeBeforeNexrScene;
    public bool PlayerIsAtTheDoor;


    // Update is called once per frame
    void Update()
    {
        if( (Input.GetKeyDown(KeyCode.E) && PlayerIsAtTheDoor == true)) {
            StartCoroutine(_OpenDoor());
        }
    }

    public IEnumerator _OpenDoor() {
        transform.GetComponent<SpriteRenderer>().sprite = OpenedDoor;
        yield return new WaitForSeconds(TimeBeforeNexrScene);
        player.SetActive(false);
        yield return new WaitForSeconds(TimeBeforeNexrScene);
        transform.GetComponent<SpriteRenderer>().sprite = ClosedDoor;
        yield return new WaitForSeconds(TimeBeforeNexrScene);
        SceneManager.LoadScene(0);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "player") {
            PlayerIsAtTheDoor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
            PlayerIsAtTheDoor = false;
    }
}