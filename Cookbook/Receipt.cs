using System.Collections.Generic;

namespace Cookbook
{
    public class Receipt
    {
        public int Id { get; set; }
        public string Name;
        public string Text;
        public List<Unit> Units { get; set; }
    }
}