using System;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public event Action<IInteractable> FinishReached;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable finish))
        {
            FinishReached?.Invoke(finish); // ����� ?. ���������� ���� ����� �� ���� �� NULL
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable _)) //_ �� ������� ������ 
        {
            FinishReached?.Invoke(null); // ���� �������� ����� �� ������� �� �����  NULL
        }
    }
}
