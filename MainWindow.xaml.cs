using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;


namespace Chess
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        
        ChessPieceDict ChessPieceDict = new ChessPieceDict();
        Game game = new();
        public static Color Blue = (Color)ColorConverter.ConvertFromString("#7095ab");
        public static Color Ice = (Color)ColorConverter.ConvertFromString("#d6e1e6");
        public int width = 0;
        public int height = 0;

        public MainWindow()
        {
            InitializeComponent();

            height = (int)(ChessBoard.Height / 8);
            width = (int)ChessBoard.Width / 8;
            InitBoard();

        }


       
        
        
        public async void InitBoard()
        {
            //Trace.WriteLine("Height: " + height);
            //Trace.WriteLine("Width: " + width
            //Make chess board
            MakeSquares();
            MakePieces(game.whitePieces);
            MakePieces(game.blackPieces);
            
            
        }

       


        // This function makes the chess squares
        public void MakeSquares()
        {
            foreach (Square square in game.board.squares)
            {
                Rectangle rect = new Rectangle();
                rect.Width = width;
                rect.Height = height;
                rect.Fill = (square.x + square.y) % 2 == 0 ? new SolidColorBrush(Ice) : new SolidColorBrush(Blue);
                rect.Stroke = Brushes.Black;
                rect.StrokeThickness = 1;
                Canvas.SetTop(rect, square.y * width);
                Canvas.SetLeft(rect, square.x * height);
                ChessBoard.Children.Add(rect);
            }

        }


        //This function takes in the game status and produces the piece visuals on the board
        private void MakePieces(Array pieces)
        {
            foreach (ChessPiece piece in pieces)
            {
                if (piece.alive == true)
                { 
                    TextBlock text = new TextBlock();
                    text.Text = piece.icon;
                    text.FontSize = piece.icon == "♟︎" ? 30 : 40;
                    text.Foreground = piece.color == "Black" ? Brushes.Black : Brushes.White;
                    text.Name = ChessPieceDict.PieceCords[piece.square.x] + (piece.square.y + 1);
                    Canvas.SetTop(text, piece.square.y * width + width / 3.5);
                    Canvas.SetLeft(text, piece.square.x * height + height / 3.5);
                    ChessBoard.Children.Add(text);
                }
            }
            
        }



        public string GetChessPiece(int i, int j)
        {
            if (i == 1 || i == 6)
            {
                return "♟︎";
            }
            else
            {
                //Use j here to get the piece as it is the column, otherwise we know it's a pawn if it's on another row
                return ChessPieceDict.GetPieceIcon(j);
            }
            
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            if(game.moves.Count % 2 == 0)
            {
                game.PlayMove("White");
            }
            else
            {
                game.PlayMove("Black");
            }

            ChessBoard.Children.Clear();
            InitBoard();
            

        }
    }
}
