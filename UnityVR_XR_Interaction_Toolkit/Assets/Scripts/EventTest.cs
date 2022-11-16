using UnityEngine;

public class EventTest : MonoBehaviour
{
    public void OnFirstHoverEntered()   // 가장 먼저 닿은 Interactor만 처리
    {
        Debug.Log($"{gameObject.name} - OnFirstHoverEntered");
    }
    public void OnLastHoverExited()   // 가장 나중에 떨어진 Interactor만 처리
    {
        Debug.Log($"{gameObject.name} - OnLastHoverExited");
    }
    public void OnHoverEntered()   // 닿았을 때
    {
        Debug.Log($"{gameObject.name} - OnHoverEntered");
    }
    public void OnHoverExited()   // 떨어졌을 때
    {
        Debug.Log($"{gameObject.name} - OnHoverExited");
    }
    public void OnFirstSelectEntered()   // 가장 먼저 grip한 Interactor만 처리
    {
        Debug.Log($"{gameObject.name} - OnFirstSelectEntered");
    }
    public void OnLastSelectExited()   // 가장 나중에 grip을 뗀 Interactor만 처리
    {
        Debug.Log($"{gameObject.name} - OnLastSelectExited");
    }
    public void OnSelectEntered()   // grip했을 때
    {
        Debug.Log($"{gameObject.name} - OnSelectEntered");
    }
    public void OnSelectExited()   // grip을 멈췄을 때
    {
        Debug.Log($"{gameObject.name} - OnSelectExited");
    }
    public void OnActived()   // active한 Interactor 처리
    {
        Debug.Log($"{gameObject.name} - OnActived");
    }
    public void OnDeactived()   // active을 멈춘 Interactor 처리
    {
        Debug.Log($"{gameObject.name} - OnDeactived");
    }
}
