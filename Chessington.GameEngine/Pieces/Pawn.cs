using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) 
            : base(player) { }
            
        private int StartingRow => Player == Player.White ? 7 : 1;

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentSquare = board.FindPiece(this);

            int direction = Player == Player.White ? -1 : 1;
            var hasMoved = currentSquare.Row != StartingRow;

            var moves = new List<Square>
            {
                Square.At(currentSquare.Row + direction, currentSquare.Col)
            };
            if (!hasMoved)
            {
                moves.Add(Square.At(currentSquare.Row + 2 * direction, currentSquare.Col));
            } 

            return moves;
        }
    }
}