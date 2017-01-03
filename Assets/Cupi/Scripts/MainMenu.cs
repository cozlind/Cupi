using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	public static bool menuPermission;
	public static bool mainMenu;

	enum ButtonValue {DefaultButton, NewGameButton, LoadGameButton, OptionsButton, AboutButton, QuitButton};
	ButtonValue menuButton;
	public static string loadName;
	public static string playerName;
	public static float musicVolume;
	public static float soundVolume;
	public static int difficulty;
	public static int playerNum;
	private static int playerSum;
	Vector2 scrollPosition;
	// Use this for initialization
	void Start () {
		playerName = "Cupi";
		playerSum = PlayerPrefs.GetInt ("PlayerSum",0);
		playerNum = 0;
		scrollPosition = Vector2.zero;
		musicVolume = PlayerPrefs.GetFloat ("musicVolume", 70);
		soundVolume = PlayerPrefs.GetFloat ("soundVolume", 70);
		difficulty = PlayerPrefs.GetInt ("difficulty", 2);
		menuPermission=false;
		mainMenu=false;
	}
	
	// Update is called once per frame

	void OnGUI()
	{
		if (menuPermission) {
						GUILayout.BeginArea (new Rect ((Screen.width - 230) / 2, (Screen.height - 200) / 2, 230, 250));
						if (menuButton == ButtonValue.DefaultButton) {	
								if(mainMenu){
									if (GUILayout.Button ("New Game")) {
										menuButton = ButtonValue.NewGameButton;
									}
								}
								if (GUILayout.Button ("Load Game")) {
										menuButton = ButtonValue.LoadGameButton;
								}
								if (GUILayout.Button ("Options")) {	
										menuButton = ButtonValue.OptionsButton;
								}
								if (GUILayout.Button ("About")) {
										menuButton = ButtonValue.AboutButton;
								}
								if(mainMenu){
									if (GUILayout.Button ("Quit"))
										Application.Quit ();
								}
								else {
										if (GUILayout.Button ("Restart"))	{
											PlayerPrefs.SetInt ("Player" + playerNum + "Site", 0);
											Globe.loadSite=0;
											Application.LoadLevel ("LoadingScene");
										}
										if (GUILayout.Button ("Main Menu"))	{
											Globe.loadName="MainScene";
										//	mainMenu=true;	
											Application.LoadLevel ("LoadingScene");
										}
										if (GUILayout.Button ("Back"))	{
											Time.timeScale=1;
											menuPermission=false;
										}
								}
						} else if (menuButton == ButtonValue.NewGameButton) {
								playerName = GUILayout.TextField (playerName, 25);
								if (GUILayout.Button ("Start")) {
										playerNum=0;
										while(playerNum<playerSum&&PlayerPrefs.HasKey ("Player"+playerNum+"Name")) playerNum++;//找到空位置或者
										if(playerNum>=playerSum)	PlayerPrefs.SetInt ("PlayerSum",++playerSum);
										PlayerPrefs.SetString ("Player" + playerNum + "Name", playerName);
										PlayerPrefs.SetInt ("Player" + playerNum + "Level", 1);
										PlayerPrefs.SetInt ("Player" + playerNum + "Site", 0);
										PlayerPrefs.SetString ("Player" + playerNum + "Time", System.DateTime.Now.ToString ());
									
										Globe.loadName=("Scene1");
										Globe.loadSite=0;
										Globe.loadNum=0;
										Application.LoadLevel ("LoadingScene");
								}
								if (GUILayout.Button ("Back")) {	
										menuButton = ButtonValue.DefaultButton;
								}
						} else if (menuButton == ButtonValue.LoadGameButton) {
								playerNum = 0;
								scrollPosition = GUILayout.BeginScrollView (scrollPosition, false, false);
								while (playerNum++<playerSum) {
										if(!PlayerPrefs.HasKey ("Player"+playerNum+"Name")) continue;
										string info_name = PlayerPrefs.GetString ("Player" + playerNum + "Name", "ERROR");
										int info_level = PlayerPrefs.GetInt ("Player" + playerNum+ "Level", 1);
										int info_site = PlayerPrefs.GetInt ("Player" + playerNum + "Site", 0);
										string info_time = PlayerPrefs.GetString ("Player" + playerNum + "Time", "ERROR");
										GUILayout.BeginHorizontal ();
												if (GUILayout.Button (info_name + "\nLevel " + info_level + "\n" + info_time)) {
														Globe.loadName = "Scene" + info_level;
														Globe.loadSite = info_site;
														Globe.loadNum=playerNum;
														Time.timeScale=1;
														Application.LoadLevel ("LoadingScene");
												}
												if (GUILayout.Button ("Delete")) {
													PlayerPrefs.DeleteKey ("Player" + playerNum + "Name");
													PlayerPrefs.DeleteKey ("Player" + playerNum + "Level");
													PlayerPrefs.DeleteKey ("Player" + playerNum + "Site");
													PlayerPrefs.DeleteKey ("Player" + playerNum + "Time");
												}
										GUILayout.EndHorizontal ();
								}
								GUILayout.EndScrollView ();
								if (GUILayout.Button ("Back")) {	
										menuButton = ButtonValue.DefaultButton;
								}
						} else if (menuButton == ButtonValue.OptionsButton) {
								GUILayout.Label ("Music Volume");
								musicVolume = GUILayout.HorizontalSlider (musicVolume, 0.0f, 100.0f);
								GUILayout.Label ("Sound Volume");
								soundVolume = GUILayout.HorizontalSlider (soundVolume, 0.0f, 100.0f);
								GUILayout.Label ("Difficulty Degree");
								difficulty = (int)GUILayout.HorizontalSlider (difficulty, 1.0f, 3.0f);

								PlayerPrefs.SetFloat ("musicVolume", musicVolume);
								PlayerPrefs.SetFloat ("soundVolume", soundVolume);
								PlayerPrefs.SetInt ("difficulty", difficulty);

								if (GUILayout.Button ("Back")) {	
										menuButton = ButtonValue.DefaultButton;
								}
						} else if (menuButton == ButtonValue.AboutButton) {
								GUILayout.Label ("Design  :  Lind \nArt  :  Lind\nProgram  :  Lind\n\nIt's just a game demo cost about one week, and it's surely a heavy work, Anyway , Thanks..\n\n_(:з」∠)_\n\n2014 10 30\n");
								if (GUILayout.Button ("Back")) {	
										menuButton = ButtonValue.DefaultButton;
								}
						}
						GUILayout.EndArea ();
				}
		}
}
