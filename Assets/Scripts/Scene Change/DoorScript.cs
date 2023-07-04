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
    public Animator transition;

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.E) && PlayerIsAtTheDoor == true))
        {
            StartCoroutine(_OpenDoor());
        }
    }

    public IEnumerator _OpenDoor()
    {
        transform.GetComponent<SpriteRenderer>().sprite = OpenedDoor;
        Debug.Log("door opened");
        yield return new WaitForSeconds(TimeBeforeNexrScene);
        //player.SetActive(false);
        FadePlayer();
        Debug.Log("Player away");
        yield return new WaitForSeconds(TimeBeforeNexrScene);
        transform.GetComponent<SpriteRenderer>().sprite = ClosedDoor;
        Debug.Log("Door closed");
        yield return new WaitForSeconds(TimeBeforeNexrScene);
        SceneManager.LoadScene(2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            PlayerIsAtTheDoor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerIsAtTheDoor = false;
    }

    private void FadePlayer()
    {
        Color tmp = player.GetComponent<SpriteRenderer>().color;
        tmp.a = 0f;
        player.GetComponent<SpriteRenderer>().color = tmp;
        // transition.SetTrigger("StartFading");
        // yield return new WaitForSeconds(1);
    }
}
