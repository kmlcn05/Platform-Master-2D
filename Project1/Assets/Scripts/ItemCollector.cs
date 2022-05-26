using TMPro;
using UnityEngine;


public class ItemCollector : MonoBehaviour
{
    public int cherries = 0;
    [SerializeField] private TextMeshProUGUI cherriesText;

    [SerializeField] private AudioSource collectionSoundEffect;

    public void Start()
    {
        cherriesText.text = "Cherries: " + (cherries + Point.point);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            cherries++;
            cherriesText.text = "Cherries: " + (cherries + Point.point);
        }
    }

}
