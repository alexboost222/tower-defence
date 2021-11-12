using Helpers;
using UnityEngine;

namespace HexagonalGrid.GridHexagon
{
    public class GridHexagonFactory : Singleton<GridHexagonFactory>
    {
        [SerializeField] private GridHexagonView template;
        
        public GridHexagonController Create(int q, int r, float size, GridHexagon.GridHexagonState state)
        {
            GridHexagon model = new GridHexagon(q, r, size, state);
            GridHexagonView view = Instantiate(template);
            return new GridHexagonController(model, view);
        }
    }
}