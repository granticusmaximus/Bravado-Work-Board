using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bravado.Models.Agile
{
    public class TaskComment
    {
        #region MAIN TASK
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Task Task { get; set; }
        public string Title { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public Priority PriorityProp { get; set; }
        #endregion
    }

    public enum Priority
    {
        Select,
        Low,
        Medium,
        High
    }
}
