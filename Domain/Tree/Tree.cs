namespace Domain.Tree
{
    public class Tree
    {
        public bool IsRoot { get; set; }
        public int Key { get; set; }
        public Tree Left { get; set; }
        public  Tree Right { get; set; }
        public  Tree Parent { get; set; }
    }
}