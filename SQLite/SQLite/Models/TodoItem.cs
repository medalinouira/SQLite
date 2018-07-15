/// Mohamed Ali NOUIRA
/// http://www.sweetmit.com
/// http://www.mohamedalinouira.com
/// https://github.com/medalinouira
/// Copyright © Mohamed Ali NOUIRA. All rights reserved.

using System;

namespace SQLite.Models
{
    [Table(nameof(TodoItem))]
    public class TodoItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public bool Done { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public DateTime Date { get; set; }
    }
}
