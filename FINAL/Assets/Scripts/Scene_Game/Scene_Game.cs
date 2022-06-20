public class Scene_Game : SceneBase {
	public void Start() {
		SoundManager.Get().PlayBGM(Constants.Sound.BGM.GAME);
	}
}
