using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timeline : MonoBehaviour {
	public int progress = 0;
	public int offset = 0;
	public Image TimelineImg;
	public Sprite[] SpriteBatch;

	private int LastProgress;

	// Use this for initialization
	void Start () {
		LastProgress = progress;
	}
	
	// Update is called once per frame
	void Update () {

		if (LastProgress != progress) {
			LastProgress = progress;

			foreach(var sprite in SpriteBatch)
			{
				var i = 0;

				int.TryParse (sprite.name, out i);

				if(i == Mathf.Max(1, Mathf.Min(40, progress - offset)))
				{
					TimelineImg.sprite = sprite;
					break;
				}
			}
		}
	}
}
