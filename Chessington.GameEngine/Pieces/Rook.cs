using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : Piece
    {
        public Rook(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var CurrentSquare = board.FindPiece(this);

            var moves = new List<Square>();

            for (var i = 0; i < GameSettings.BoardSize; i++)
                {
                    if (i != CurrentSquare.Row)
                    {
                        moves.Add(Square.At(i, CurrentSquare.Col));
                    }
                }
                
                for (var i = 0;i < GameSettings.BoardSize; i++)
                {
                    if (i != CurrentSquare.Col)
                    {
                        moves.Add(Square.At(CurrentSquare.Row, i));
                    }
                }

            return moves;
        }
    }
}