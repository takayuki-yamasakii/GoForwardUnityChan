using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {

    //　キューブの移動速度
	private float speed = -12;

	// 消滅位置
	private float deadLine = -10;

	// 効果音
	private AudioSource audioSource;



	// Use this for initialization
	void Start()
	{
		//　cubeの効果音を取得
		audioSource = gameObject.GetComponent<AudioSource>();
    }

	// Update is called once per frame
	void Update()
	{

		//　キューブを移動させる
		transform.Translate(this.speed * Time.deltaTime, 0, 0);

		//　画面外に出たら破棄する
		if (transform.position.x < this.deadLine)
		{
			Destroy(gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{

		if (collision.gameObject.tag == "CubePrefab")

		{
			//　キューブ同士が重なったとき音を鳴らす
			audioSource.Play();
			GetComponent<AudioSource>().volume = 3;

		}
		if (collision.gameObject.tag == "Ground")
		{
			audioSource.Play();
			GetComponent<AudioSource>().volume = 3;
		}
	}   
}
