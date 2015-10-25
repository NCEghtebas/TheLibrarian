using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;


public class FillBooks : MonoBehaviour {
	public BookLogic book_1;
	public BookLogic book_2;
	public BookLogic book_3;
	public BookLogic book_4;
	public BookLogic book_5;
	public BookLogic book_6;
	
	public string m_category;

	void Start(){
		string url = "https://"+m_category+".hearst.io/api/v1/articles?section_id=2&visibility=1&all_images=0&get_image_cuts=0&ignore_cache=0&limit=10&order_by=date+desc&_key=vau2bqeepwtfygwt2444pksw";
		WWW www = new WWW(url);
		StartCoroutine (WaitForRequest (www));
	}

	private ArrayList getUrls(string data){
		ArrayList urls = new ArrayList ();
		Match match = Regex.Match(data, "\"url\":\"([^\"]*)");
		while (match.Success) {
			string url_str = match.ToString ().Remove (0, 7);
			urls.Add(url_str);
			match = match.NextMatch();
		}
		return urls;
	}

	private ArrayList getTitles(string data){
		ArrayList titles = new ArrayList ();
		Match match = Regex.Match (data, "\"title\":\"([^\"]*)");
		while (match.Success) {
			string title = match.ToString ().Remove (0, 9);
			titles.Add (title);
			match = match.NextMatch();
		}
		return titles;
	}

	private void printList(ArrayList theList){
		foreach (var el in theList) {
			Debug.Log (el);
		}
	}

	IEnumerator WaitForRequest(WWW www)
	{
		yield return www;
		// check for errors
		if (www.error == null) {
			ArrayList urls = getUrls (www.data);
			ArrayList titles = getTitles (www.data);

			book_1.setUrl ((string)urls[0]);
			book_1.setTitle((string)titles[0]);
			book_2.setUrl ((string)urls[1]);
			book_2.setTitle((string)titles[1]);
			book_3.setUrl ((string)urls[2]);
			book_3.setTitle((string)titles[2]);
			book_4.setUrl ((string)urls[3]);
			book_4.setTitle((string)titles[3]);
			book_5.setUrl ((string)urls[4]);
			book_5.setTitle((string)titles[4]);
			book_6.setUrl ((string)urls[5]);
			book_6.setTitle((string)titles[5]);

//			printList (urls);
//			printList (titles);

		} else {
			Debug.Log ("WWW Error: " + www.error);
		} 
	}

	// Update is called once per frame
	void Update () {
	
	}
}
