using UnityEngine;

public class BubbleEmitter : MonoBehaviour
{
    public GameObject[] bubblePrefab;
    public Transform emitterPoint;

    public float tick;

    private void Update()
    {
        tick -= Time.deltaTime;
        if (tick < 0)
        {
            EmitBubble();
            tick = 5f;
        }
    }

    private void EmitBubble()
    {
        var prefab = UnityEngine.Random.Range(0, bubblePrefab.Length);
        var i = Instantiate(bubblePrefab[prefab], emitterPoint.position, Quaternion.identity);
    }
}