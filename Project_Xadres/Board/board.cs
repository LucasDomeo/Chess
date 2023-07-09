namespace Board
{
    class boardd
    {
        public int line { get; set; }
        public int column { get; set; }
        private Pieces[,] pieces;

        public boardd(int line, int column)
        {
            this.line = line;
            this.column = column;
            pieces = new Pieces[line, column];
        }

        public Pieces piece (int line, int column)
        {
            return pieces[line, column];
        }
    }
}
