using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 表示针的行为
/// </summary>
public class NeedleBehaviour : MonoBehaviour {
    public static float speed;
	// Use this for initialization
	void Start () {
      //  speed = 5;
	}
	
	// Update is called once per frame
	void Update () {
        
        transform.Translate(transform.up * Time.deltaTime * speed);
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Wheel")
        {
            speed = 0;
            transform.SetParent(collision.transform,true);
            transform.localScale = new Vector3(1,1,1);
            Mannger.needleNumber++;
          
            Mannger.instance.NewNeedle();
            transform.GetComponent<NeedleBehaviour>().enabled = false;
        }else if (collision.transform.tag == "Needle")
        {
            Mannger.isGameOver = true;
            Time.timeScale = 0;
        }
    }
    
}
