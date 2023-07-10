using Board;

namespace Board
{
    class Pieces
    {
        public Position position { get; set; }
        public Color color { get; protected set; }
        public int NBMoviments { get; protected set; }
        public board bd { get; protected set; }

        public Pieces(board bd , Color color)
        {
            this.position = null;
            this.color = color;
            this.bd = bd;
            NBMoviments = 0;
        }

        public void NBMovimentsMethod()
        {
            NBMoviments++;
        }
    }
}
