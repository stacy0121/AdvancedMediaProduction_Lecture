using UnityEngine;

public class EventTest : MonoBehaviour
{
    public void OnFirstHoverEntered()   // ���� ���� ���� Interactor�� ó��
    {
        Debug.Log($"{gameObject.name} - OnFirstHoverEntered");
    }
    public void OnLastHoverExited()   // ���� ���߿� ������ Interactor�� ó��
    {
        Debug.Log($"{gameObject.name} - OnLastHoverExited");
    }
    public void OnHoverEntered()   // ����� ��
    {
        Debug.Log($"{gameObject.name} - OnHoverEntered");
    }
    public void OnHoverExited()   // �������� ��
    {
        Debug.Log($"{gameObject.name} - OnHoverExited");
    }
    public void OnFirstSelectEntered()   // ���� ���� grip�� Interactor�� ó��
    {
        Debug.Log($"{gameObject.name} - OnFirstSelectEntered");
    }
    public void OnLastSelectExited()   // ���� ���߿� grip�� �� Interactor�� ó��
    {
        Debug.Log($"{gameObject.name} - OnLastSelectExited");
    }
    public void OnSelectEntered()   // grip���� ��
    {
        Debug.Log($"{gameObject.name} - OnSelectEntered");
    }
    public void OnSelectExited()   // grip�� ������ ��
    {
        Debug.Log($"{gameObject.name} - OnSelectExited");
    }
    public void OnActived()   // active�� Interactor ó��
    {
        Debug.Log($"{gameObject.name} - OnActived");
    }
    public void OnDeactived()   // active�� ���� Interactor ó��
    {
        Debug.Log($"{gameObject.name} - OnDeactived");
    }
}
