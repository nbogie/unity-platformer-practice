using UnityEngine;

public class Collectable : MonoBehaviour
{

    [SerializeField]
    private string collectableName;

    private AudioSource audioSource;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player p = collision.gameObject.GetComponent<Player>();
        if (p)
        {
            InventorySystem invSys = collision.GetComponent<InventorySystem>();
            if (invSys)
            {
                Debug.Log("Collected " + name + ": " + collectableName);
                invSys.IncrementCountOf(collectableName);
                AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);
                Destroy(gameObject);
            }

        }
    }

}
