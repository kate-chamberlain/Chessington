using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentSquare = board.FindPiece(this);

            var moves = new List<Square>();

            var directions = new List<(int RowChange, int ColChange)>
            {
                (1, 1),
                (1, -1),
                (-1, 1),
                (-1, -1)
            };

            foreach (var direction in directions)
            {
                var row = currentSquare.Row + direction.RowChange;
                var col = currentSquare.Col + direction.ColChange;

                while (row >=0 && row < GameSettings.BoardSize && col >= 0 && col < GameSettings.BoardSize)
                {
                    moves.Add(Square.At(row, col));
                    row += direction.RowChange;
                    col += direction.ColChange;
                }
            }


            return moves;
        }
    }
}