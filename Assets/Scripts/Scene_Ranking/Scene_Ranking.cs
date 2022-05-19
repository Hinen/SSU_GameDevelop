using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_Ranking : SceneBase {
	public void OnClickTest() {
		RankingManager.Get().InsertRanking("hinen", 1234);
	}
}
