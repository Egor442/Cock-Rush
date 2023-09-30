using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text _currentScore;
    [SerializeField] private TMP_Text _countScore;
    [SerializeField] private List<Chick> _chickPoints = new List<Chick>();

    public int CountCollectChicks { get; private set; }
    public IReadOnlyList<Chick> ChickPoints => _chickPoints;

    private void OnEnable()
    {
        foreach (var chickPoint in ChickPoints)
        {
            chickPoint.Reached += ChangeCurrentScore;
        }
    }

    private void OnDisable()
    {
        foreach (var chickPoint in ChickPoints)
        {
            chickPoint.Reached -= ChangeCurrentScore;
        }
    }

    private void Start()
    {
        _countScore.text = ChickPoints.Count.ToString();
    }

    private void ChangeCurrentScore()
    {
        CountCollectChicks++;
        _currentScore.text = CountCollectChicks.ToString();
    }
}