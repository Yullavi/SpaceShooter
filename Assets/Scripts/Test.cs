using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour 
{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
  //      var pos = transform.position;
  //      pos.y += Time.deltaTime;
	//    transform.position = pos;
	}

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Sphere")
        {
            Debug.Log("Ой");
        }
    }


}
