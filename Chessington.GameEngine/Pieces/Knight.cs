using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        public Knight(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentSquare = board.FindPiece(this);
            var moves = new List<Square>();

            var directions = new List<(int RowChange, int ColChange)>
            {
                (-2, 1),
                (-2, -1),
                (-1, 2),
                (-1, -2),
                (1, 2),
                (1, -2),
                (2, 1),
                (2, -1)
            };

            foreach (var direction in directions)
            {
               var row = currentSquare.Row + direction.RowChange;
               var col = currentSquare.Col + direction.ColChange;

               if (row >= 0 && row < GameSettings.BoardSize && col >= 0 && col < GameSettings.BoardSize)
               {
                   moves.Add(Square.At(row, col));
               }
            }
            return moves;
        }
    }
}