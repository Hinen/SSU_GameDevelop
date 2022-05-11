public static class Constants {
	public const int RESOLUTION_X = 2436;
	public const int RESOLUTION_Y = 1125;

	public const int BACKGROUND_X_RANGE = RESOLUTION_X / 2 - 150;
	
	public const float BACKGROUND_Y_DIFF = 365f;

	public static class SceneName {
		public const string SCENE_TITLE = "Scene_Title";
		public const string SCENE_SELECT_CHARACTER = "Scene_SelectCharacter";
		public const string SCENE_GAME = "Scene_Game";
	}

	public static class Player {
		public const int PLAYER_MAX_HP = 100;
		
		public const float PLAYER_DEFAULT_MOVE_SPEED = 800f;
		public const float PLAYER_SPEED_UP_MOVE_SPEED = 1400f;

		public const float PLAYER_JUMP_UP_TIME = 0.3f;
		public const float PLAYER_JUMP_MAX_HEIGHT = 200f;
	}

	public static class Sound {
		public const string BGM_TITLE = "BGM_TITLE";
		public const string BGM_GAME = "BGM_GAME";
	}
}