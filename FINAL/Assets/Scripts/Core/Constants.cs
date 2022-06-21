public static class Constants {
	public const int RESOLUTION_X = 574;
	public const int RESOLUTION_Y = 1024;
	
	public const float BACKGROUND_X_RANGE = RESOLUTION_X / 2f - 50f;

	public static class SceneName {
		public const string SCENE_INIT = "Scene_Init";
		public const string SCENE_TITLE = "Scene_Title";
		public const string SCENE_GAME = "Scene_Game";
		public const string SCENE_RANKING = "Scene_Ranking";
		public const string SCENE_GAME_END = "Scene_GameEnd";
	}

	public static class Sound {
		public class BGM {
			public const string TITLE = "BGM_TITLE";
			public const string GAME = "BGM_GAME";
		}
	}

	public static class Player {
		public const float MOVE_SPEED = 1000f;
		public const float MAX_MOVE_VELOCITY = 500f;
		public const float JUMP_POWER = 1000f;
	}

	public static class LevelDesign {
		public const float CLOUD_SPAWN_TERM_Y = 200f;
	}
}