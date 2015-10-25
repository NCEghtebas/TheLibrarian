using UnityEngine;
using System.Collections;

public class BookLogic : MonoBehaviour {
	public string m_url;
	public GameObject m_title;

	public void setUrl(string str){
		m_url = str;
	}
	public void setTitle(string str){
		TextMesh mesh=m_title.GetComponent<TextMesh>();
		mesh.text = str;

	}
	public string getUrl(){
		return m_url;
	}
}
