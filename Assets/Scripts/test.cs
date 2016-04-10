using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class test : MonoBehaviour {
	public UnityEngine.UI.Slider slider;
	public float slider_val;
	public Text text;
	public float temp;
	public GameObject test_obj, test_obj2;
	public int x=10;
	public int y=1;
	public int z=10;
	public int cnt;
	public TextAsset txt_file;
	public TextAsset scale_file;
	public string str;
	public string str_scale;
	string[] arr;
	string[] scale;
	public GameObject parent;
	[SerializeField] public GameObject[] GameObjectArray;

	// Use this for initialization
	void Start () {
		text = gameObject.GetComponent<Text> ();
 		str = txt_file.text;
		arr = str.Split (' '); 
		str_scale = scale_file.text;
		scale=str_scale.Split(' ');

		Cycle_obj(1967.00f);
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetButton("SliderUp")) {

			slider.value +=1.0f;
		}
		if (Input.GetButton("SliderDown")) {

			slider.value -=1.0f;
		}
		//slider_val = slider.value;

		//change_text (temp);

		//Debug.Log (slider_val);
	}

//	public void onValueChanged(float newval){
//		temp = slider_val;
//		change_text (temp);
//	}

	public void change_text(float temp){
//		Debug.Log(arr);
//		for (int i = 0; i < arr.Length; i++) {
//			Debug.Log (arr [i]);
//		}
//




		//parent.BroadcastMessage ("receiveMessage", temp,SendMessageOptions.DontRequireReceiver);
		Cycle_obj(temp);
		int index = (int)(temp - 1967.00);
//		string t = temp + "-";
//		Debug.Log (arr.Length);
//		t += arr [index];
		if (index == (arr.Length - 1)) {

			text.text = temp +"-" + "$30,176";
			test_obj.transform.localScale = new Vector3 (62f,62f, 62f);
			test_obj2.transform.localScale = new Vector3 (62f,62f, 62f);
		} 
		else if (index == 0) {
			text.text = temp + "-" + "$15,276";
			test_obj.transform.localScale = new Vector3 (30f,30f, 30f);
			test_obj2.transform.localScale = new Vector3 (30f,30f, 30f);
		}

		//Debug.Log ("First index"+arr [index]);
		//Debug.Log (index);
		else {

			text.text = temp + "-" +"$"+ arr [arr.Length-index-1];
			float sc = float.Parse(scale [index]);
			test_obj.transform.localScale = new Vector3 (sc,sc,sc);
			test_obj2.transform.localScale = new Vector3 (sc,sc,sc);
		}

	
//		if (temp==1974.00) {
//			cnt++;
//			Debug.Log ("Inside change_Text");
//			text.text = "30,556$";
//			test_obj.transform.localScale = new Vector3 (35f,35f, 35f);
//		}
//		if (temp==1975.00) {
//			cnt++;
//			Debug.Log ("Inside change_Text");
//			text.text = "30,556$";
//			test_obj.transform.localScale = new Vector3 (35f,35f, 35f);
//		}
//		if (temp==1976.00) {
//			cnt++;
//			Debug.Log ("Inside change_Text");
//			text.text = "30,556$";
//			test_obj.transform.localScale = new Vector3 (35f,35f, 35f);
//		}
//		if (temp==1977.00) {
//			cnt++;
//			Debug.Log ("Inside change_Text");
//			text.text = "30,556$";
//			test_obj.transform.localScale = new Vector3 (35f,35f, 35f);
//		}
//		if (temp==1976.00) {
//			cnt++;
//			Debug.Log ("Inside change_Text");
//			text.text = "30,556$";
//			test_obj.transform.localScale = new Vector3 (35f,35f, 35f);
//		}
//		if (temp==1977.00) {
//			cnt++;
//			Debug.Log ("Inside change_Text");
//			text.text = "30,556$";
//			test_obj.transform.localScale = new Vector3 (35f,35f, 35f);
//		}
//		if (temp==1978.00) {
//			cnt++;
//			Debug.Log ("Inside change_Text");
//			text.text = "30,556$";
//			test_obj.transform.localScale = new Vector3 (35f,35f, 35f);
//		}
//		if (temp==1979.00) {
//			cnt++;
//			Debug.Log ("Inside change_Text");
//			text.text = "30,556$";
//			test_obj.transform.localScale = new Vector3 (35f,35f, 35f);
//		}
//		if (temp==1980.00) {
//			cnt++;
//			Debug.Log ("Inside change_Text");
//			text.text = "30,556$";
//			test_obj.transform.localScale = new Vector3 (35f,35f, 35f);
//		}
//		if (temp==1981.00) {
//			cnt++;
//			Debug.Log ("Inside change_Text");
//			text.text = "30,556$";
//			test_obj.transform.localScale = new Vector3 (35f,35f, 35f);
//		}
//		if (temp==1982.00) {
//			cnt++;
//			Debug.Log ("Inside change_Text");
//			text.text = "30,556$";
//			test_obj.transform.localScale = new Vector3 (35f,35f, 35f);
//		}
//		if (temp==1983.00) {
//			cnt++;
//			Debug.Log ("Inside change_Text");
//			text.text = "30,556$";
//			test_obj.transform.localScale = new Vector3 (35f,35f, 35f);
//		}
//		if (temp==1984.00) {
//			cnt++;
//			Debug.Log ("Inside change_Text");
//			text.text = "30,556$";
//			test_obj.transform.localScale = new Vector3 (35f,35f, 35f);
//		}
//		if (temp==1985.00) {
//			cnt++;
//			Debug.Log ("Inside change_Text");
//			text.text = "30,556$";
//			test_obj.transform.localScale = new Vector3 (35f,35f, 35f);
//		}
//		if (temp==1986.00) {
//			cnt++;
//			Debug.Log ("Inside change_Text");
//			text.text = "30,556$";
//			test_obj.transform.localScale = new Vector3 (35f,35f, 35f);
//		}
//		if (temp==1987.00) {
//			cnt++;
//			Debug.Log ("Inside change_Text");
//			text.text = "30,556$";
//			test_obj.transform.localScale = new Vector3 (35f,35f, 35f);
//		}
//		if (temp==1988.00) {
//			cnt++;
//			Debug.Log ("Inside change_Text");
//			text.text = "30,556$";
//			test_obj.transform.localScale = new Vector3 (35f,35f, 35f);
//		}
//		if (temp==1989.00) {
//			cnt++;
//			Debug.Log ("Inside change_Text");
//			text.text = "30,556$";
//			test_obj.transform.localScale = new Vector3 (35f,35f, 35f);
//		}
//		if (temp==1990.00) {
//			cnt++;
//			Debug.Log ("Inside change_Text");
//			text.text = "30,556$";
//			test_obj.transform.localScale = new Vector3 (35f,35f, 35f);
//		}
//		if (temp==1991.00) {
//			cnt++;
//			Debug.Log ("Inside change_Text");
//			text.text = "30,556$";
//			test_obj.transform.localScale = new Vector3 (35f,35f, 35f);
//		}
//		if (temp==1992.00) {
//			cnt++;
//			Debug.Log ("Inside change_Text");
//			text.text = "30,556$";
//			test_obj.transform.localScale = new Vector3 (35f,35f, 35f);
//		}
//		if (temp==1993.00) {
//			cnt++;
//			Debug.Log ("Inside change_Text");
//			text.text = "30,556$";
//			test_obj.transform.localScale = new Vector3 (35f,35f, 35f);
//		}
//		if (temp==1994.00) {
//			cnt++;
//			Debug.Log ("Inside change_Text");
//			text.text = "30,556$";
//			test_obj.transform.localScale = new Vector3 (35f,35f, 35f);
//		}
//		if (temp==1995.00) {
//			cnt++;
//			Debug.Log ("Inside change_Text");
//			text.text = "30,556$";
//			test_obj.transform.localScale = new Vector3 (35f,35f, 35f);
//		}
//		if (temp==1996.00) {
//			cnt++;
//			Debug.Log ("Inside change_Text");
//			text.text = "30,556$";
//			test_obj.transform.localScale = new Vector3 (35f,35f, 35f);
//		}
//		if (temp==1997.00) {
//			cnt++;
//			Debug.Log ("Inside change_Text");
//			text.text = "30,556$";
//			test_obj.transform.localScale = new Vector3 (35f,35f, 35f);
//		}
//		if (temp==1998.00) {
//			cnt++;
//			Debug.Log ("Inside change_Text");
//			text.text = "30,556$";
//			test_obj.transform.localScale = new Vector3 (35f,35f, 35f);
//		}
//		if (temp==1999.00) {
//			cnt++;
//			Debug.Log ("Inside change_Text");
//			text.text = "30,556$";
//			test_obj.transform.localScale = new Vector3 (35f,35f, 35f);
//						}
//
//		else if (temp==2000.00) {
//			cnt++;
//			Debug.Log ("Inside change_Text");
//			text.text = "30,556$";
//			test_obj.transform.localScale = new Vector3 (35f,35f, 35f);
//	
//		}
//		else if (temp==2001.00) {
//			text.text = "2001--29,995$";
//			test_obj.transform.localScale = new Vector3 (30f, 30f, 30f);
//
//		}
//		else if (temp==2002.00) {
//			text.text = "2002--28,961$";
//			test_obj.transform.localScale = new Vector3 (30f, 30f, 30f);
//
//		}	
//		else if (temp==2003.00) {
//			text.text = "2003--29,901$";
//			test_obj.transform.localScale = new Vector3 (32f, 32f, 32f);
//
//		}
//		else if (temp==2004.00) {
//			text.text = "2004--30,350$";
//			test_obj.transform.localScale = new Vector3 (35f, 35f, 35f);
//
//		}
//		else if (temp==2005.00) {
//			text.text = "2005--30,943$";
//			test_obj.transform.localScale = new Vector3 (35f, 35f, 35f);
//
//		}
//		else if (temp==2006.00) {
//			text.text = "2006--30,605$";
//			test_obj.transform.localScale = new Vector3 (38f, 38f, 38f);
//
//		}
//		else if (temp==2007.00) {
//			text.text = "2007--29,649$";
//			test_obj.transform.localScale = new Vector3 (32f, 32f, 32f);
//
//		}
//		else if (temp==2008.00) {
//			text.text = "2008--29,274$";
//			test_obj.transform.localScale = new Vector3 (30f, 30f, 30f);
//
//		}
//		else if (temp==2009.00) {
//			text.text = "2009--28,838$";
//			test_obj.transform.localScale = new Vector3 (28f, 28f, 28f);
//
//		}
//		else if (temp==2010.00) {
//			text.text = "2010--29,005$";
//			test_obj.transform.localScale = new Vector3 (27f, 27f, 27f);
//
//		}
//		else if (temp==2011.00) {
//			text.text = "2011--29,161$";
//			test_obj.transform.localScale = new Vector3 (27f, 27f, 27f);
//
//		}
//		else if (temp==2012.00) {
//			text.text = "2012--29,301$";
//			test_obj.transform.localScale = new Vector3 (30f, 30f, 30f);
//
//		}else if (temp==2013.00) {
//			text.text = "2013--30,518$";
//			test_obj.transform.localScale = new Vector3 (35f, 35f, 35f);
//
//		}
//		else if (temp==2014.00) {
//			text.text = "2014--30,176$";
//			test_obj.transform.localScale = new Vector3 (35f, 35f, 35f);
//
//		}
	}

	public void Cycle_obj(float temp){
		Debug.Log ("Size of array:"+GameObjectArray.Length);
		for (int i = 0; i < GameObjectArray.Length; i++) {
			if(GameObjectArray[i]!=null){
			GameObjectArray [i].SetActive (true);
			}
		
		}
		parent.BroadcastMessage ("receiveMessage", temp);

	
	}


}
