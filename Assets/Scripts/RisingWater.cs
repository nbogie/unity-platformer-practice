using UnityEngine;

public class RisingWater : MonoBehaviour {

    [SerializeField]
    private float riseSpeed;

	void Start () {
		
	}
	
	void Update () {
        transform.Translate(Vector3.up * Time.deltaTime * riseSpeed);	
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("trigger entered with water");
        Player player = collision.GetComponent<Player>();
        if (player)
        {
            player.TakeDamage(10000f);
        }
    }
}
