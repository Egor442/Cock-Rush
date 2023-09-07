using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text _currentScore;
    [SerializeField] private TMP_Text _countScore;
    
    public Chick[] ChickPoints {get; private set;}
    public int CountCollectChicks {get; private set;}

    private void Awake()
    {
        ChickPoints = FindObjectsOfType<Chick>();
    }

    private void OnEnable()
    {
        foreach (var chickPoint in ChickPoints)
            chickPoint.Reached += ChangeCurrentScore;
    }

    private void OnDisable()
    {
        foreach (var chickPoint in ChickPoints)
            chickPoint.Reached -= ChangeCurrentScore;
    }

    private void Start()
    {
        _countScore.text = ChickPoints.Length.ToString();
    }

    private void ChangeCurrentScore()
    {
        CountCollectChicks++;
        _currentScore.text = CountCollectChicks.ToString();
    }
}