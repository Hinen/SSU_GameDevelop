using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene_Ranking : SceneBase {
	[SerializeField]
	private RankingCell _rankingCellPrefab;

	[SerializeField]
	private GridLayoutGroup _cellGroup;

	private List<RankingManager.RankingInfo> _rankingInfolist;
	private bool _isRankingInited;
	
	public void Start() {
		RankingManager.Get().GetRankings(
			delegate(List<RankingManager.RankingInfo> list) {
				_rankingInfolist = list;
			});
	}

	public void Update() {
		if (_isRankingInited)
			return;
		
		if (_rankingInfolist == null)
			return;

		RefreshRankingCells(_rankingInfolist);
	}

	private void RefreshRankingCells(List<RankingManager.RankingInfo> list) {
		for (int i = 0; i < list.Count; i++) {
			var rankingInfo = list[i];

			var cell = Instantiate(_rankingCellPrefab, _cellGroup.transform);
			cell.Init(i + 1, rankingInfo.name, rankingInfo.score);
		}

		_isRankingInited = true;
	}
	
	public void OnClickTest() {
		RankingManager.Get().InsertRanking("hinen", 1234);
	}
}
