using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taggable : MonoBehaviour
{
    public TagManager tagManager;
    private float noTagPeriod = 1.0f;

    [SerializeField]
    private bool canTag = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TagYouAreIt()
    {
        tagManager.SetWhoIsIt(gameObject);
        StartCoroutine(TagCooldown());
    }

    IEnumerator TagCooldown()
    {
        yield return new WaitForSeconds(noTagPeriod);
        canTag = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        Taggable other;
        if (canTag && (other = collision.gameObject.GetComponent<Taggable>()))
        {
            other.TagYouAreIt();
            canTag = false;
        }
    }

    public bool GetCanTag()
    {
        return canTag;
    }
}
