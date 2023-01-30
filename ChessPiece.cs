namespace Chess
{
    internal class ChessPiece
    {

        public int id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public string color { get; set; }

        public Square square { get; set; }
        public bool alive { get; set; }

        ChessPieceDict ChessPieceDict = new ChessPieceDict();
        public ChessPiece(int x, string color, Square square)
        {
            //this constructor is used for the regular pieces
            id = x;
            name = ChessPieceDict.GetPieceName(x);
            icon = ChessPieceDict.GetPieceIcon(x);
            this.color = color;
            alive = true;
            this.square = square;
        }

        public ChessPiece(int x, string name, string icon, string color, Square square)
        {
            //this constructor is used for the pawns
            id = x;
            this.name = name;
            this.icon = icon;
            this.color = color;
            alive = true;
            this.square = square;

        }

        public ChessPiece(int x, string name, string icon, string color, Square square, bool alive)
        {
            //this constructor is used for the pawns
            id = x;
            this.name = name;
            this.icon = icon;
            this.color = color;
            this.alive = alive;
            this.square = square;

        }

        public void SetSquare(Square square)
        {
            this.square = square;
        }





    }
}





