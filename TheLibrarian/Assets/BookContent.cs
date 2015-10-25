using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public class BookContent : MonoBehaviour {
	public ArrayList m_titles;

	// Use this for initialization
	void Start(){
		string url = "https://popularmechanics.hearst.io/api/v1/articles?section_id=2&visibility=1&all_images=0&get_image_cuts=0&ignore_cache=0&limit=10&order_by=date+desc&_key=vau2bqeepwtfygwt2444pksw";
		WWW www = new WWW(url);
		StartCoroutine(WaitForRequest(www));
	}

	IEnumerator WaitForRequest(WWW www)
	{
		yield return www;
		// check for errors
		if (www.error == null)
		{
			Debug.Log("WWW Ok!: " + www.data);
			Match match = Regex.Match(www.data, "\"title\":\"([^\"]*)");
			while (match.Success) {
				string title = match.ToString().Remove(0,9);
				m_titles.Add(title);
				match = match.NextMatch();
			}
		} else {
			Debug.Log("WWW Error: "+ www.error);
		}   
	}
	// Update is called once per frame
	void Update () {
	
	}
}
