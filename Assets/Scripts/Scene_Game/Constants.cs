public static class Constants {
	public const int RESOLUTION_X = 2436;
	public const int RESOLUTION_Y = 1125;

	public const int BACKGROUND_X_RANGE = RESOLUTION_X / 2 - 150;
	
	public const float BACKGROUND_Y_DIFF = 365f;

	public static class Player {
		public const int PLAYER_MAX_HP = 100;
		public const float PLAYER_MOVE_SPEED = 800f;

		public const float PLAYER_JUMP_UP_TIME = 0.3f;
		public const float PLAYER_JUMP_MAX_HEIGHT = 200f;
	}

	public static class Sound {
		public const string BGM_TITLE = "BGM_TITLE";
		public const string BGM_GAME = "BGM_GAME";
	}
}