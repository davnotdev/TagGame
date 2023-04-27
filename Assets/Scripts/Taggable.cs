using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taggable : MonoBehaviour
{
    public TagManager tagManager;
    private float noTagPeriod = 5.0f;
    private bool canTag = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void TagYouAreIt()
    {
        StartCoroutine(TagCooldown());
        canTag = true;
    }

    IEnumerator TagCooldown()
    {
        yield return new WaitForSeconds(noTagPeriod);
    }

    void OnCollisionEnter(Collision collision)
    {
        Taggable other;
        if (canTag && (other = collision.gameObject.GetComponent<Taggable>()))
        {
            other.TagYouAreIt();
        }
        canTag = false;
    }

    public bool GetCanTag()
    {
        return canTag;
    }
}
