using UnityEngine;
using UnityEngine.UI;

public class RankingCell : MonoBehaviour {
    [SerializeField]
    private Text _nameText;
    
    [SerializeField]
    private Text _scoreText;

    public void Init(int rank, string name, int score) {
        _nameText.text = $"{rank}. {name}";
        _scoreText.text = score.ToString();
    }
}
