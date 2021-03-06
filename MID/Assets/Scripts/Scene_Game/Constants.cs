public static class Constants {
	public const int RESOLUTION_X = 2436;
	public const int RESOLUTION_Y = 1125;

	public const int BACKGROUND_X_RANGE = RESOLUTION_X / 2 - 150;
	
	public const float BACKGROUND_Y_DIFF = 115f;

	public static class SceneName {
		public const string SCENE_INIT = "Scene_Init";
		public const string SCENE_TITLE = "Scene_Title";
		public const string SCENE_SELECT_CHARACTER = "Scene_SelectCharacter";
		public const string SCENE_GAME = "Scene_Game";
		public const string SCENE_RANKING = "Scene_Ranking";
		public const string SCENE_GAME_END = "Scene_GameEnd";
	}

	public static class Player {
		public const float PLAYER_DEFAULT_MOVE_SPEED = 800f;
		public const float PLAYER_SPEED_UP_MOVE_SPEED = 1400f;

		public const float PLAYER_JUMP_UP_TIME = 0.3f;
		public const float PLAYER_JUMP_MAX_HEIGHT = 200f;
	}

	public static class Sound {
		public class BGM {
			public const string TITLE = "BGM_TITLE";
			public const string GAME = "BGM_GAME";
		}
		
		public class FX {
			public const string ATTACKED = "FX_ATTACKED";
			public const string TOUCH = "FX_TOUCH";
			public const string JUMP = "FX_JUMP";
			public const string CAT = "FX_CAT";
			public const string TIME_STOP = "FX_TIME_STOP";
		}
	}
}