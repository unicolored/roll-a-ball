using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float speed;
	//private countText;
	public GUIText countText;
	public GUIText winText;
	private int count; 

	void Start()
	{
		count = 0;
		SetCountText();
		winText.text = "";
	}

	void Update()
	{
		// before rendering frame
	}

	void FixedUpdate()
	{
		// before performing physics
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal,0.0f,moveVertical);

		GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime); 
	}

	void OnTriggerEnter(Collider other)
	{
        if(other.gameObject.tag == "PickUp")
        {
        	other.gameObject.SetActive(false);
        	count = count + 1;
        	SetCountText();
        }
    }

    void SetCountText()
    {
    	countText.text = "Count: " + count.ToString();
    	if (count>=9)
    	{
    		winText.text = "You win !";
    	}
    	
    }

}