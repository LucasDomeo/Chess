using Board;

namespace Board
{
    class Pieces
    {
        public Position position { get; set; }
        public Color color { get; protected set; }
        public int NBMoviments { get; protected set; }
        public boardd bd { get; protected set; }

        public Pieces(boardd bd , Color color)
        {
            this.position = null;
            this.color = color;
            this.bd = bd;
            NBMoviments = 0;
        }
    }
}
