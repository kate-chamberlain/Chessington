using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Queen : Piece
    {
        public Queen(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
      
            var currentSquare = board.FindPiece(this);

            var moves = new List<Square>();

            // Lateral movement
            for (var i = 0; i < GameSettings.BoardSize; i++)
                {
                    if (i != currentSquare.Row)
                    {
                        moves.Add(Square.At(i, currentSquare.Col));
                    }
                }
                
                for (var i = 0;i < GameSettings.BoardSize; i++)
                {
                    if (i != currentSquare.Col)
                    {
                        moves.Add(Square.At(currentSquare.Row, i));
                    }
                }

            // Diagonal movement
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