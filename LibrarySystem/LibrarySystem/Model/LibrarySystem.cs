namespace LibrarySystem.Model
{
    using System;
    using System.Collections.Generic;

    public partial class Users
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Pass { get; set; }
        public string Email { get; set; }
        public Nullable<int> Year { get; set; }
        public char Type { get; set; }
        public string DOB { get; set; }
        public string Join { get; set; }
    }
    public partial class Books
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public Nullable<int>Year { get; set; }
        public Nullable<int>Availbility { get; set; }
        public char Type { get; set; }
        public char Status { get; set; }
    }
    public partial class Borrowed
    {
        public int UserID { get; set; }
        public int BookID { get; set; }
        public string Borrow { get; set; }
        public string Return { get; set; }
        public char Status { get; set; }

    }
}