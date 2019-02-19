using System;

namespace Studbud.Data
{
    public class Transaction
    {
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        public string Catagory { get; set; }
        public string Merchant { get; set; }
        public decimal Amount { get; set; }
        public Guid Guid { get; set; }
    }
    /// <summary>
    /// List of predefined catagories.
    /// </summary>
    public static class CatagoryNames
    {
        public const string Utility = "Utility";
        public const string Transportation = "Transportation";
        public const string Dining = "Dining";
        public const string Social = "Social";
    }
}
