using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bravado.Models.Agile
{
    public class Task
    {
        #region MAIN TASK
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string BoardId { get; set; }
        public int ListNum { get; set; }
        public string Title { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool Open { get; set; }
        #endregion

        #region
        public Guid SubId { get; set; }
        public string SubTitle { get; set; }
        [DataType(DataType.MultilineText)]
        public string SubDescription { get; set; }
        public DateTime SubDueDate { get; set; }
        #endregion
    }
}
