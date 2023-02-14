using UnityEngine;

public class AlarmZone : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<RogueController>(out RogueController rogue))
        {
            _alarm.IncreaseVolume();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<RogueController>(out RogueController rogue))
        {
            _alarm.DecreaseVolume();
        }
    }
}
