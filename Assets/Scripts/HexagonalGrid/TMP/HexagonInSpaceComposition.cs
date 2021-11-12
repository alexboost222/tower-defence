using UnityEngine;

namespace HexagonalGrid.TMP
{
    public class HexagonInSpaceComposition : MonoBehaviour
    {
        [SerializeField] private int q;
        [SerializeField] private int r;
        [SerializeField] private float size;

        private void Awake()
        {
            HexagonInSpace model = new HexagonInSpace(q, r, size);
            HexagonInSpaceView view = gameObject.AddComponent<HexagonInSpaceView>();
            new HexagonInSpaceController(model, view);
            Destroy(this);
        }
    }
}