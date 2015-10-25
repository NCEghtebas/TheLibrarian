using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public class BookContent : MonoBehaviour {
	public ArrayList m_titles;
	public GameObject m_title;
	public bool m_go;

	// Use this for initialization
	void Start(){
		string url = "https://popularmechanics.hearst.io/api/v1/articles?section_id=2&visibility=1&all_images=0&get_image_cuts=0&ignore_cache=0&limit=10&order_by=date+desc&_key=vau2bqeepwtfygwt2444pksw";
		WWW www = new WWW(url);
		if (m_go) {
			StartCoroutine (WaitForRequest (www));
		}
	}

	IEnumerator WaitForRequest(WWW www)
	{
		yield return www;
		// check for errors
		if (www.error == null)
		{
			Debug.Log("WWW Ok!: " + www.data);
			Match match = Regex.Match(www.data, "\"title\":\"([^\"]*)");
			Match urlmatch = Regex.Match(www.data, "\"url\":\"([^\"]*)");
			if (match.Success && urlmatch.Success){
				string title = match.ToString().Remove(0,9);
				string url_str=urlmatch.ToString ().Remove(0,7);;
				TextMesh mesh=m_title.GetComponent<TextMesh>();
				Debug.Log ("Title:"+title);
				Debug.Log ("Url:"+url_str);
				mesh.text=title;
				Application.OpenURL(url_str);

			}
//			while (match.Success) {
//				string title = match.ToString().Remove(0,9);
//				m_titles.Add(title);
//				match = match.NextMatch();
//			}
//			TextMesh mesh=m_title.GetComponent<TextMesh>();
//			Debug.Log ("Title:"+(string)m_titles[0]);
//			mesh.text=(string)m_titles[0];
		} else {
			Debug.Log("WWW Error: "+ www.error);
		}   
	}
	// Update is called once per frame
	void Update () {
	}
}
