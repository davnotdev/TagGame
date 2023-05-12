using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct Powers
{
    public bool speed;
    public bool shield;

    static float speedDuration = 10.0f;
}

public class Taggable : MonoBehaviour
{
    private float noTagPeriod = 1.0f;

    public AudioClip GettingTagged;
    private AudioSource source; 


    [SerializeField]
    private bool canTag = false;
    private TagManager tagManager;

    [SerializeField]
    private Powers powers;

    // Start is called before the first frame update
    void Start()
    {
        tagManager = TagManager.GetTagManager();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool TagYouAreIt(GameObject tagger)
    {
        source.PlayOneShot(GettingTagged);

        if (powers.shield)
        {
            tagger.GetComponent<PushBack>().PushMeBack(transform.position);
            return (powers.shield = false);
        }

        tagManager.SetWhoIsIt(gameObject);
        StartCoroutine(TagCooldown());
        return true;
    }

    IEnumerator TagCooldown()
    {
        yield return new WaitForSeconds(noTagPeriod);
        canTag = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!canTag && collision.gameObject.CompareTag("Shield"))
        {
            ObtainShield();
            Destroy(collision.gameObject);
        }

        /* if (!canTag && collision.gameObject.CompareTag("Speed")) */
        /* { */
        /*     ObtainSpeed(); */
        /* } */

        Taggable other;
        if (canTag && (other = collision.gameObject.GetComponent<Taggable>()))
        {
            if (other.TagYouAreIt(gameObject))
            {
                canTag = false;
            }
        }
    }

    void ObtainShield()
    {
        powers.shield = true;
    }

    public bool GetCanTag()
    {
        return canTag;
    }
}
