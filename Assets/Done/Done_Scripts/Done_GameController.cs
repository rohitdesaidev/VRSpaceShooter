using UnityEngine;
using System.Collections;

public class Done_GameController : MonoBehaviour
{
	public GameObject[] hazards;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	
	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;
	
	private bool gameOver;
	private bool restart;
	private int score;
	
	void Start ()
	{
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
	}
	
	void Update ()
	{
		if (restart)
		{
			if (Input.GetKeyDown (KeyCode.R))
			{
				Application.LoadLevel (Application.loadedLevel);
			}
		}

		if (gameOver) {
			if (Input.GetButton("Fire1") ||Input.GetKeyDown (KeyCode.Space)) 
			{
				
				Application.LoadLevel (Application.loadedLevel);

			}
		
		}

	

			if (Input.GetKeyDown (KeyCode.Escape)) {

				if (Cardboard.SDK.VRModeEnabled) {

					Cardboard.SDK.VRModeEnabled = false;

			}else{
					Application.Quit ();
				}


			}
		


	}
	
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				GameObject hazard = hazards [Random.Range (0, hazards.Length)];
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
			
			if (gameOver)
			{
				restartText.text = "";
				restart = true;
				break;
			}
		}
	}

	void OnGUI() {

		if (!Cardboard.SDK.VRModeEnabled) {
			if(GUI.Button(new Rect(30,100,150,60), "VR MODE")) {
				Cardboard.SDK.VRModeEnabled = true;
			}
		}
	

	}


	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}
	
	void UpdateScore ()
	{
		scoreText.text = "Score: " + score;
	}
	
	public void GameOver ()
	{
		gameOverText.text = "Game Over!\n Tap To Restart";
		gameOver = true;
	}
}