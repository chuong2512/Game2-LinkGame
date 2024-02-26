using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LineRender : MonoBehaviour {
	
	public GameObject TopDown;

	public GameObject BottomUp;

	public GameObject Verical;

	public GameObject Horizontal;

	public GameObject Center;

	private Vector3 bottomRightLinePos = new Vector3(0.45f,-0.45f,0);
	private Vector3 topRightLinePos = new Vector3(0.45f,0.45f,0);
	private Vector3 bottomLeftLinePos = new Vector3(-0.45f,-0.45f,0);
	private Vector3 topLeftLinePos = new Vector3(-0.45f,0.45f,0);
	private Vector3 bottomLinePos = new Vector3(0,0.45f,0);
	private Vector3 topLinePos = new Vector3(0,-0.45f,0);
	private Vector3 leftLinePos = new Vector3(-0.45f,0,0);
	private Vector3 rightLinePos = new Vector3(0.45f,0,0);

	public bool isUsed = false;

	//private readonly object _lock = new object();
	// Use this for initialization
	void Awake () {

	}

	public void DrawLine(Trend trend, Vector3 position)
	{
		isUsed = true;
		switch (trend)
		{
		case Trend.Bottom:
			DrawVerical(position+bottomLinePos);
			break;
		case Trend.BottomLeft:
			DrawBottomUp(position+bottomLeftLinePos);
			break;
		case Trend.BottomRight:
			DrawTopDown(position + bottomRightLinePos);
			break;
		case Trend.Left:
			DrawHorizontal(position + leftLinePos);
			break;
		case Trend.Right:
			DrawHorizontal(position + rightLinePos);
			break;
		case Trend.Top:
			DrawVerical(position + topLinePos);
			break;
		case Trend.TopLeft:
			DrawTopDown(position + topLeftLinePos);
			break;
		case Trend.TopRight:
			DrawBottomUp(position + topRightLinePos);
			break;
		default:
			break;
		}
	}

	protected void DrawTopDown(Vector3 position)
	{
		TopDown.transform.position = position;
		TopDown.SetActive (true);
	}

	protected void DrawBottomUp(Vector3 position)
	{
		BottomUp.transform.position = position;
		BottomUp.SetActive (true);
	}

	protected void DrawVerical(Vector3 position)
	{
		Verical.transform.position = position;
		Verical.SetActive (true);
	}	

	protected void DrawHorizontal(Vector3 position)
	{
		Horizontal.transform.position = position;
		Horizontal.SetActive (true);
	}

	public void DrawCenter(Vector3 position)
	{
		Center.transform.position = position;
		Center.SetActive (true);
	}

	public void UnUsed()
	{
		TopDown.SetActive (false);
		BottomUp.SetActive (false);
		Verical.SetActive (false);
		Horizontal.SetActive (false);
		Center.SetActive(false);
		isUsed = false;
	}
	
}
