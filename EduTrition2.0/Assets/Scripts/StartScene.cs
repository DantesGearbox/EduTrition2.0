using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScene : MonoBehaviour
{
	public int playfieldRadius;
	public Text userText;
	public static StartScene instance;

	private void Awake()
	{
		if (instance != null)
		{
			Destroy(gameObject);
			return;
		}

		instance = this;
		DontDestroyOnLoad(gameObject);
	}

	public void OnBeginButton()
	{
		playfieldRadius = int.Parse(userText.text);
	}

	public void ChangeScene()
	{
		SceneManager.LoadScene("GPSEduTrition");
	}
}
