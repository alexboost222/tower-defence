using UnityEngine;

namespace HexagonalGrid
{
    public class HexagonalGridComposition : MonoBehaviour
    {
        [SerializeField] private HexagonalGridView viewTemplate;

        private void Awake()
        {
            HexagonalGrid model = new HexagonalGrid {Radius = 4, HexagonSize = 1};
            HexagonalGridView view = Instantiate(viewTemplate);
            new HexagonalGridController(model, view);
            Destroy(gameObject);
        }
    }
}