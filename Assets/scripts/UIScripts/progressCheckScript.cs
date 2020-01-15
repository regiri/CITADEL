using System.Collections;
using UnityEngine;

public class progressCheckScript : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[5];
    public GameObject obj;
    IEnumerator Times() {
        obj.GetComponent<SpriteRenderer>().sprite = sprites[0];
        yield return new WaitForSeconds(.1f);
        obj.GetComponent<SpriteRenderer>().sprite = sprites[1];
        yield return new WaitForSeconds(.1f);
        obj.GetComponent<SpriteRenderer>().sprite = sprites[2];
        yield return new WaitForSeconds(.1f);
        obj.GetComponent<SpriteRenderer>().sprite = sprites[3];
        yield return new WaitForSeconds(.1f);
        obj.GetComponent<SpriteRenderer>().sprite = sprites[4];
    }
    void Start() {
        StartCoroutine("Times");
    }
}
